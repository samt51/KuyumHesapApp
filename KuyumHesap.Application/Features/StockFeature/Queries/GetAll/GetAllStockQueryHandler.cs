using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetAll
{
    public class GetAllStockQueryHandler : BaseHandler, IRequestHandler<GetAllStockQueryRequest, ResponseDto<List<GetAllStockQueryResponse>>>
    {
        public GetAllStockQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        public async Task<ResponseDto<List<GetAllStockQueryResponse>>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork
         .GetReadRepository<Stock>()
         .GetAllAsync(
             x => !x.IsDeleted,
             include: q => q
                .Include(s => s.StockGroup)
                // include StockType AND its Currency so mapper can read CurrencyCode
                .Include(s => s.StockType)
                    .ThenInclude(st => st.Currency)
         );

            var mappedData = mapper.Map<List<GetAllStockQueryResponse>>(data);

            var movements = await unitOfWork.GetReadRepository<Movements>()
                .GetAllAsync(x => !x.IsDeleted);

            foreach (var stock in mappedData)
            {
                var stockMovements = movements.Where(x => x.StockId == stock.Id).ToList();
                stock.Quantity = stockMovements.Sum(x =>
                    (x.TransactionTypeId == 1 || x.TransactionTypeId == 2 || x.TransactionTypeId == 3 ? (x.Quantity ?? 0m) : 0m)
                  - (x.TransactionTypeId == 4 || x.TransactionTypeId == 5 || x.TransactionTypeId == 6 ? (x.Quantity ?? 0m) : 0m)
                );
            }

            return new ResponseDto<List<GetAllStockQueryResponse>>().Success(mappedData);
        }
    }
}
