using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Commands.Delete
{
    public class DeleteProductTypeCommandHandler : BaseHandler, IRequestHandler<DeleteProductTypeCommandRequest, ResponseDto<DeleteProductTypeCommandResponse>>
    {
        public DeleteProductTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteProductTypeCommandResponse>> Handle(DeleteProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ProductType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<ProductType>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteProductTypeCommandResponse>().Success();
        }
    }
}
