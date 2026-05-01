using EllipticCurve.Utils;
using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterReport
{
    public class GetFilterReportQueryHandler : BaseHandler, IRequestHandler<GetFilterReportQueryRequest, ResponseDto<List<GetFilterReportQueryResponse>>>
    {
        private readonly IAccountStatementQuery _accountStatementQuery;
        public GetFilterReportQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAccountStatementQuery accountStatementQuery) : base(mapper, unitOfWork)
        {
            _accountStatementQuery = accountStatementQuery;
        }

        public async Task<ResponseDto<List<GetFilterReportQueryResponse>>> Handle(GetFilterReportQueryRequest request, CancellationToken cancellationToken)
        {
            var startDate = request.StartDate.Date;

            var endDate = request.EndDate.Date
                .AddDays(1)
                .AddTicks(-1); // 23:59:59.9999999
            var response = new List<GetFilterReportQueryResponse>();
            if (request.FilterType == Dtos.Enums.FilterEnum.FinancialSummary)
            {
                var accountData = await unitOfWork.GetReadRepository<Account>().GetAllAsync(c => !c.IsDeleted && c.AccountTypeId == request.TypeId);
                var filterData = request.TypeValueId == null || request.TypeValueId == 0 ? null : accountData.Where(c => c.Id == request.TypeValueId.GetValueOrDefault());

                var ids = filterData == null ? accountData.Select(c => c.Id).ToArray() : filterData.Select(c => c.Id).ToArray();


                var currencyId = request?.CurrencyId?.Length == 0 || request?.CurrencyId == null ? null : request.CurrencyId;

                var currencyCode = currencyId != null ? await unitOfWork.GetReadRepository<Currency>().GetAllAsync(c => currencyId.Contains(c.Id)) : null;

                var filteredEkstre = await _accountStatementQuery.GetFinancialViewByFilterBetweenDate(ids, currencyCode?.Select(c => c.CurrencyCode)?.ToArray(), startDate, endDate, cancellationToken);

                foreach (var item in filteredEkstre)
                {
                    response.Add(new GetFilterReportQueryResponse
                    {
                        ReceiptId = item.ReceiptId,
                        MovementId = item.MovementId,
                        ReceiptDate = item.ReceiptDate,
                        TransactionName = item.TransactionName,
                        Quantity = item.Quantity,
                        Unit = item.Unit,
                        ExchangeRate = item.Rate,
                        CounterQuantity = item.CounterQuantity,
                        CounterUnit = item.CounterUnit,
                        CounterExchangeRate = item.CounterRate,
                        Description = item.Description,
                        IsEntry = item.IsEntry,
                        StockName = item.StockName,
                        MillRate = item.MillRate,
                        LaborCost = item.LaborCost,
                        LaborUnit = item.LaborUnit,
                        IsReconciled = item.IsReconciled,
                        NetProductValue = item.NetProductValue,
                        TotalLaborCost = item.TotalLaborCost,
                        BalanceEffectAmount = item.BalanceEffectAmount,
                        BalanceCurrency = item.BalanceUnit,
                        StockUnit = item.StockUnit,
                        AccountId = item.AccountId,
                        AccountName = item.AccountName,
                        AccountTypeName = item.AccountTypeName,
                        TransactionTypeId = item.TransactionTypeId,
                        ForeignCurrencyId = item.ForeignCurrencyId
                    });
                }

            }

            if (request.FilterType == Dtos.Enums.FilterEnum.StockSummary)
            {
                var stockData = await unitOfWork.GetReadRepository<Stock>().GetAllAsync(c => !c.IsDeleted && c.StockGroupId == request.TypeId);

                var filterData = request.ProductId == null || request.ProductId == 0 ? null : stockData.Where(c => c.Id == request.ProductId);

                var ids = filterData == null ? stockData.Select(c => c.Id).ToArray() : filterData.Select(c => c.Id).ToArray();

                var filteredEkstre = await _accountStatementQuery.GetStockViewByFilterBetweenDate(ids, request.StartDate, request.EndDate, cancellationToken);

                foreach (var item in filteredEkstre)
                {
                    response.Add(new GetFilterReportQueryResponse
                    {
                        ReceiptId = item.ReceiptId,
                        MovementId = item.MovementId,
                        ReceiptDate = item.ReceiptDate,
                        TransactionName = item.TransactionName,
                        Quantity = item.Quantity,
                        Unit = item.Unit,
                        ExchangeRate = item.Rate,
                        CounterQuantity = item.CounterQuantity,
                        CounterUnit = item.CounterUnit,
                        CounterExchangeRate = item.CounterRate,
                        Description = item.Description,
                        IsEntry = item.IsEntry,
                        StockName = item.StockName,
                        MillRate = item.MillRate,
                        LaborCost = item.LaborCost,
                        LaborUnit = item.LaborUnit,
                        IsReconciled = item.IsReconciled,
                        NetProductValue = item.NetProductValue,
                        TotalLaborCost = item.TotalLaborCost,
                        BalanceEffectAmount = item.BalanceEffectAmount,
                        BalanceCurrency = item.BalanceUnit,
                        StockUnit = item.StockUnit,
                        AccountId = item.AccountId,
                        AccountName = item.AccountName,
                        AccountTypeName = item.AccountTypeName,
                        TransactionTypeId = item.TransactionTypeId,
                        ForeignCurrencyId = item.ForeignCurrencyId
                    });
                }
            }

            return new ResponseDto<List<GetFilterReportQueryResponse>>().Success(response); 
        }
    }
}
