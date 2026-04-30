using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;
using KuyumHesap.Domain.Entities;
using MediatR;
using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetStockReport
{
    public class GetStockReportQueryHandler : BaseHandler, IRequestHandler<GetStockReportQueryRequest, ResponseDto<GetStockReportQueryResponse>>
    {
        private readonly IAccountStatementQuery _accountStatementQuery;
        public GetStockReportQueryHandler(IAccountStatementQuery accountStatementQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountStatementQuery = accountStatementQuery;
        }

        public async Task<ResponseDto<GetStockReportQueryResponse>> Handle(GetStockReportQueryRequest request, CancellationToken cancellationToken)
        {
            var ekstre = new GetStockReportQueryResponse();
            var responseItem = new List<GetStockReportQueryItemResponse>();
            var items = new GetStockReportQueryItemResponse();

            var baslangic = Convert.ToDateTime("1970-01-01");
            var bitis = Convert.ToDateTime("31.12.9999 00:00:00");// Bitiş tarihini gün sonu olarak ayarla
            var accountByCach = await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.Id == request.StockGroupAccounId && !x.IsDeleted);
            var cachAccoundIds = new int[1];
            cachAccoundIds.SetValue(request.StockGroupAccounId, 0);
            // Hesap ve tarih filtresi: istenen müşterinin, endDate öncesi kayıtları
            var devredenBalance = await _accountStatementQuery.GetViewByAccountIds(cachAccoundIds, baslangic, bitis, cancellationToken);

            items = new();
            items.AccountId = accountByCach.Id;
            items.AccountName = accountByCach.AccountName;
            items.DevredenBakiyeler = devredenBalance.Where(c => c.AccountId == accountByCach.Id).Select(b => new EkstreBakiyeViewModel
            {
                CurrencyCode = b.DovizKodu,
                Balance = b.Balance
            }).ToList();
            items.Hareketler = new List<EkstreSatirViewModel>();
            responseItem.Add(items);

            var filteredEkstre = await _accountStatementQuery.GetViewByAccountIdsBetweenDate(cachAccoundIds, baslangic, bitis, cancellationToken);
            var listEkstre = new List<EkstreSatirViewModel>();

            var hasQuantity = await unitOfWork.GetReadRepository<ExchangeRate>().GetAsync(c => c.CurrencyId == 1, orderBy: y => y.OrderByDescending(y => y.RateDate));

            foreach (var item in filteredEkstre)
            {

                listEkstre.Add(new EkstreSatirViewModel
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
                    LaborQuantity = item.LaborQuantity,
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
                    StockId = item.StockId
                });
            }
            decimal totalHas = 0;
            decimal totalQuantity = 0;
            foreach (var item in responseItem)
            {


                var dataEkstre = listEkstre.Where(c => c.AccountId == item.AccountId).ToList();

                var bakiyeTakip = item.DevredenBakiyeler.ToDictionary(b => b.CurrencyCode, b => b.Balance);
                var hasQuantityRate = hasQuantity.BuyRate;
                foreach (var hareket in dataEkstre)
                {
                    string bakiyeBirimi = hareket.CounterUnit;
                    decimal bakiyeEtkiMiktari = hareket.BalanceEffectAmount;

                    if (string.IsNullOrEmpty(bakiyeBirimi)) continue;

                    if (!bakiyeTakip.ContainsKey(bakiyeBirimi)) { bakiyeTakip[bakiyeBirimi] = 0; }

                    decimal eskiBakiye = bakiyeTakip[bakiyeBirimi];
                    decimal yeniBakiye = eskiBakiye + (!hareket.IsEntry ? bakiyeEtkiMiktari : -bakiyeEtkiMiktari);
                    bakiyeTakip[bakiyeBirimi] = yeniBakiye;

                    hareket.OldBalance = eskiBakiye;
                    hareket.FinalBalance = yeniBakiye;

                    item.Hareketler.Add(hareket);

                    item.TotalHas += hareket.NetProductValue.GetValueOrDefault();
                    totalHas += item.TotalHas;
                    totalQuantity += hareket.Quantity;
                }
            }
            ekstre.Items = responseItem;
            ekstre.TotalQuantity = totalQuantity;
            ekstre.TotalHas = Math.Round(totalHas, 2, MidpointRounding.AwayFromZero);

            return new ResponseDto<GetStockReportQueryResponse>().Success(ekstre);
        }
        public async Task<decimal> GetRate(string currencyCode)
        {
            if (currencyCode == "TRY")
            {
                return 1;
            }
            var rate = await unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAsync(x => x.Currency.CurrencyCode == currencyCode, orderBy: y => y.OrderByDescending(y => y.RateDate));
            return rate.BuyRate;
        }
    }
}
