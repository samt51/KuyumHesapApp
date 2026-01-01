using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Commands.Update
{
    public class UpdateProductTypeCommandHandler : BaseHandler, IRequestHandler<UpdateProductTypeCommandRequest, ResponseDto<UpdateProductTypeCommandResponse>>
    {
        public UpdateProductTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateProductTypeCommandResponse>> Handle(UpdateProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ProductType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mappedData = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<ProductType>().UpdateAsync(mappedData);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateProductTypeCommandResponse>().Success();
        }
    }
}
