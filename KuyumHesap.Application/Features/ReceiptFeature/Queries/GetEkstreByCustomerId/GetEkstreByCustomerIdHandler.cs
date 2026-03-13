using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;
using KuyumHesap.Domain.Entities;
using MediatR;
using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId
{
    public class GetEkstreByCustomerIdHandler : BaseHandler, IRequestHandler<GetEkstreByCustomerIdRequest, ResponseDto<EkstreViewModel>>
    {
        string toggleName;
        private readonly IAccountStatementQuery _accountStatementQuery;
        public GetEkstreByCustomerIdHandler(IAccountStatementQuery accountStatementQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountStatementQuery = accountStatementQuery;
        }

        public async Task<ResponseDto<EkstreViewModel>> Handle(GetEkstreByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var ekstre = new EkstreViewModel();
            // Önce view'den extre verilerini çek
            List<AccountStatementViewResponseModel> totalBalance;
            try
            {
                totalBalance = await _accountStatementQuery.GetAsync(cancellationToken);
            }
            catch (Exception)
            {
                // view sorgusu başarısızsa hata fırlat
                throw;
            }

            var baslangic = request.StartDate.Date;
            var bitis = request.EndDate.Date.AddDays(1).AddTicks(-1); // Bitiş tarihini gün sonu olarak ayarla

            // Hesap ve tarih filtresi: istenen müşterinin, endDate öncesi kayıtları
            var dataBalance = totalBalance
                .Where(x => x.AccountId == request.CustomerId && x.ReceiptDate < request.EndDate)
                .ToList();

            // Döviz bazında bakiye hesapla:
            // SUM(CASE WHEN IsEntry = 1 THEN BalanceEffectAmount ELSE -BalanceEffectAmount END) AS Bakiye
            var devredenBalance = dataBalance
                .GroupBy(x => (x.BalanceUnit ?? string.Empty).Trim())
                .Select(g => new EkstreBakiyeViewModel
                {
                    CurrencyCode = g.Key,
                    Balance = g.Sum(item => (item.IsEntry ? item.BalanceEffectAmount : -item.BalanceEffectAmount))
                })
                .ToList();

            ekstre.DevredenBakiyeler = devredenBalance;

            var filteredEkstre = new List<AccountStatementViewResponseModel>();

            try
            {
                filteredEkstre = await _accountStatementQuery.GetViewByAccountIdaAndStartBetweenEndDate(request.CustomerId, baslangic, bitis, cancellationToken);

            }
            catch (Exception)
            {

                throw;
            }


            var listEkstre = new List<EkstreSatirViewModel>();
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

            var bakiyeTakip = devredenBalance.ToDictionary(b => b.CurrencyCode, b => b.Balance);

            foreach (var hareket in listEkstre)
            {
                string bakiyeBirimi = hareket.Unit;
                decimal bakiyeEtkiMiktari = hareket.BalanceEffectAmount;

                if (string.IsNullOrEmpty(bakiyeBirimi)) continue;

                if (!bakiyeTakip.ContainsKey(bakiyeBirimi)) { bakiyeTakip[bakiyeBirimi] = 0; }

                decimal eskiBakiye = bakiyeTakip[bakiyeBirimi];
                decimal yeniBakiye = eskiBakiye + (hareket.IsEntry ? bakiyeEtkiMiktari : -bakiyeEtkiMiktari);
                bakiyeTakip[bakiyeBirimi] = yeniBakiye;

                hareket.OldBalance = eskiBakiye;
                hareket.FinalBalance = yeniBakiye;

                ekstre.Hareketler.Add(hareket);
            }

            return new ResponseDto<EkstreViewModel>().Success(ekstre);
        }
        /// <summary>
        /// Extre bakiyelerini dönen basit view modeli.
        /// </summary>
        public class EkstreBakiyeViewModel
        {
            /// <summary>
            /// Döviz kodu (ör. HAS, USD, EUR)
            /// </summary>
            public string CurrencyCode { get; set; } = "";

            /// <summary>
            /// Döviz cinsinden bakiye
            /// </summary>
            public decimal Balance { get; set; }
        }


        /// <summary>
        /// Ekstre satırının view modeli (vw_HesapEkstresi'den gelen satır karşılığı).
        /// </summary>
        public class EkstreSatirViewModel
        {
            /// <summary>
            /// Cari Hesap Id
            /// </summary>
            public int AccountId { get; set; }
            public string AccountName { get; set; } = null!;
            public string AccountTypeName { get; set; } = null!;

            public decimal? OpenBalanceAmount { get; set; }
            /// <summary>
            /// Fiş (Receipt) kimliği
            /// </summary>
            public int ReceiptId { get; set; }

            /// <summary>
            /// Hareket (Movement) kimliği
            /// </summary>
            public int MovementId { get; set; }

            /// <summary>
            /// İşlem tarihi
            /// </summary>
            public DateTime ReceiptDate { get; set; }

            /// <summary>
            /// İşlem/işlem tipi Id
            /// </summary>
            public int TransactionTypeId { get; set; }

            /// <summary>
            /// İşlem/işlem tipi adı
            /// </summary>
            public string TransactionName { get; set; } = "";

            /// <summary>
            /// Açıklama
            /// </summary>
            public string? Description { get; set; }

            /// <summary>
            /// Giriş mi (true = giriş, false = çıkış)
            /// </summary>
            public bool IsEntry { get; set; }

            /// <summary>
            /// Miktar (stok veya döviz cinsinden)
            /// </summary>
            public decimal Quantity { get; set; }

            /// <summary>
            /// Birim kodu / adı
            /// </summary>
            public string Unit { get; set; } = "";

            /// <summary>
            /// Döviz / stok kuru
            /// </summary>
            public decimal ExchangeRate { get; set; }

            /// <summary>
            /// Karşılık miktar (döviz veya miktar)
            /// </summary>
            public decimal? CounterQuantity { get; set; }

            /// <summary>
            /// Karşılık birimi
            /// </summary>
            public string? CounterUnit { get; set; }

            /// <summary>
            /// Karşılık döviz kuru
            /// </summary>
            public decimal? CounterExchangeRate { get; set; }

            /// <summary>
            /// Önceki bakiye (satır işlendiğindeki önceki bakiye)
            /// </summary>
            public decimal OldBalance { get; set; }

            /// <summary>
            /// Sonraki / güncel bakiye (satır işlendiğinden sonra)
            /// </summary>
            public decimal FinalBalance { get; set; }

            /// <summary>
            /// Stok adı
            /// </summary>
            public string? StockName { get; set; }

            /// <summary>
            /// Milyem / ayar oranı
            /// </summary>
            public decimal? MillRate { get; set; }

            /// <summary>
            /// İşçilik tutarı
            /// </summary>
            public decimal? LaborCost { get; set; }

            /// <summary>
            /// İşçilik birimi (örn. adet, saat)
            /// </summary>
            public string? LaborUnit { get; set; }

            /// <summary>
            /// Mutabakat durumu (true = mutabakat sağlanmış)
            /// </summary>
            public bool IsReconciled { get; set; }

            /// <summary>
            /// Ürünün NET HAS değeri
            /// </summary>
            public decimal? NetProductValue { get; set; }

            /// <summary>
            /// Toplam işçilik tutarı
            /// </summary>
            public decimal? TotalLaborCost { get; set; }

            /// <summary>
            /// Bakiyeye etki eden miktar (view'deki BalanceEffectAmount)
            /// </summary>
            public decimal BalanceEffectAmount { get; set; }

            /// <summary>
            /// Bakiyenin para birimi / birim kodu (ör. HAS, USD)
            /// </summary>
            public string BalanceCurrency { get; set; } = "";

            /// <summary>
            /// Tutar (base currency / BPBR karşılığı gibi): view'deki Tutar_BPBR
            /// </summary>
            public decimal BaseCurrencyAmount { get; set; }

            /// <summary>
            /// Stok birimi (view'deki StockUnit / UnitName)
            /// </summary>
            public string StockUnit { get; set; } = "";
        }

        public class EkstreViewModel
        {
            public List<EkstreBakiyeViewModel> DevredenBakiyeler { get; set; } = new();
            public List<EkstreSatirViewModel> Hareketler { get; set; } = new();
        }
    }
}
