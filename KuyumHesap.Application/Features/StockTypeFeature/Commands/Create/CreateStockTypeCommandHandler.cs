using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Commands.Create
{
    public class CreateStockTypeCommandHandler : BaseHandler, IRequestHandler<CreateStockTypeCommandRequest, ResponseDto<CreateStockTypeCommandResponse>>
    {
        public CreateStockTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateStockTypeCommandResponse>> Handle(CreateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var mapData = mapper.Map<StockType, CreateStockTypeCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<StockType>().AddAsync(mapData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateStockTypeCommandResponse>().Success();
        }
    }
}
