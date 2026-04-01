using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;
using KuyumHesap.Domain.Entities;
using MediatR;
using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryHandler : BaseHandler, IRequestHandler<GetCashReportQueryRequest, ResponseDto<EkstreViewModel>>
    {
        private readonly IAccountStatementQuery _accountStatementQuery;
        public GetCashReportQueryHandler(IAccountStatementQuery accountStatementQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountStatementQuery = accountStatementQuery;
        }

        public async Task<ResponseDto<EkstreViewModel>> Handle(GetCashReportQueryRequest request, CancellationToken cancellationToken)
        {
            var ekstre = new EkstreViewModel();
            // Önce view'den extre verilerini çek
            List<AccountStatementViewResponseModel> totalBalance;

            var baslangic = Convert.ToDateTime("1970-01-01");
            var bitis = Convert.ToDateTime("31.12.9999 00:00:00");// Bitiş tarihini gün sonu olarak ayarla
            var accountByCach = await unitOfWork.GetReadRepository<Account>().GetAllAsync(x => x.AccountTypeId == 7 && !x.IsDeleted);
            var cachAccoundIds = accountByCach.Select(x => x.Id).ToArray();
            // Hesap ve tarih filtresi: istenen müşterinin, endDate öncesi kayıtları
            var devredenBalance = await _accountStatementQuery.GetViewByAccountIds(cachAccoundIds, baslangic, bitis, cancellationToken);
            ekstre.DevredenBakiyeler = devredenBalance.Select(b => new EkstreBakiyeViewModel
            {
                CurrencyCode = b.DovizKodu,
                Balance = b.Balance
            }).ToList();

            totalBalance = await _accountStatementQuery.GetAsync(cancellationToken);
            var filteredEkstre = new List<AccountStatementViewResponseModel>();
            filteredEkstre = await _accountStatementQuery.GetViewByAccountIdsBetweenDate(cachAccoundIds, baslangic, bitis, cancellationToken);
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
                    IsReconciled = item.IsReconciled,
                    NetProductValue = item.NetProductValue,
                    TotalLaborCost = item.TotalLaborCost,
                    BalanceEffectAmount = item.BalanceEffectAmount,
                    BalanceCurrency = item.BalanceUnit,
                    StockUnit = item.StockUnit,
                    AccountId = item.ReceiptAccounId,
                    AccountName = item.ReceiptAccountName,
                    AccountTypeName = item.ReceiptAccounTypeName,
                    TransactionTypeId = item.TransactionTypeId
                });
            }

            var bakiyeTakip = devredenBalance.ToDictionary(b => b.DovizKodu, b => b.Balance);

            listEkstre = listEkstre.OrderByDescending(x => x.ReceiptDate).ToList();
            var hasQuantityRate = hasQuantity.BuyRate;
            foreach (var hareket in listEkstre)
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
                ekstre.Hareketler.Add(hareket);
            }
            decimal totalHas = 0;
            // Hareketler bittikten sonra güncel bakiyelerden TotalHas hesapla
            foreach (var bakiye in bakiyeTakip)
            {
                if (bakiye.Value < 0)
                    continue;
                string dovizKodu = bakiye.Key;
                decimal tutar = bakiye.Value;

                decimal hasValue = 0;

                if (dovizKodu == "HAS")
                {
                    hasValue = tutar;
                }
                else
                {
                    hasValue = (tutar * await GetRate(dovizKodu)) / hasQuantityRate;
                }

                totalHas += hasValue;
            }

            ekstre.TotalHas = Math.Round(totalHas, 2, MidpointRounding.AwayFromZero);

            return new ResponseDto<EkstreViewModel>().Success(ekstre);
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
