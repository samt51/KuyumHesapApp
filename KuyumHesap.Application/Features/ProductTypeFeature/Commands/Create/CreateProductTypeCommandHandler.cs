using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Commands.Create
{
    public class CreateProductTypeCommandHandler : BaseHandler, IRequestHandler<CreateProductTypeCommandRequest, ResponseDto<CreateProductTypeCommandResponse>>
    {
        public CreateProductTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateProductTypeCommandResponse>> Handle(CreateProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var mapData = mapper.Map<ProductType, CreateProductTypeCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<ProductType>().AddAsync(mapData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateProductTypeCommandResponse>().Success();
        }
    }
}
