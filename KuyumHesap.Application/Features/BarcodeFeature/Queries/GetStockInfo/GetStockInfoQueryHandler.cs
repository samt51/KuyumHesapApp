using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockInfo
{
    public class GetStockInfoQueryHandler : BaseHandler, IRequestHandler<GetStockInfoQueryRequest, ResponseDto<GetStockInfoQueryResponse>>
    {
        public GetStockInfoQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetStockInfoQueryResponse>> Handle(GetStockInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Stock>().GetAsync(x => !x.IsDeleted && x.Id == request.StockId);


            var list = await unitOfWork.GetReadRepository<Movements>()
    .GetAllAsync(x => !x.IsDeleted && x.StockId == request.StockId);

            var totalQuantity = list.Sum(x =>
                (x.TransactionTypeId == 1 || x.TransactionTypeId == 2 || x.TransactionTypeId == 3 ? (x.Quantity ?? 0m) : 0m)
              - (x.TransactionTypeId == 4 || x.TransactionTypeId == 5 || x.TransactionTypeId == 6 ? (x.Quantity ?? 0m) : 0m)
            );

            var totalLabor = list.Sum(x =>
                (x.TransactionTypeId == 1 || x.TransactionTypeId == 2 || x.TransactionTypeId == 3 ? (x.LaborCost ?? 0m) : 0m)
              - (x.TransactionTypeId == 4 || x.TransactionTypeId == 5 || x.TransactionTypeId == 6 ? (x.LaborCost ?? 0m) : 0m)
            );

            var rsp = new GetStockInfoQueryResponse
            {
                Id = data.Id,
                StockName = data.StockName,
                UnitName = data.UnitName,
                MillRate = data.MillRate,
                Quantity = totalQuantity,
                LaborCost = totalLabor,
            };

            return new ResponseDto<GetStockInfoQueryResponse>().Success(rsp);



        }
    }
}
