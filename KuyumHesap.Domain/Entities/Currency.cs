using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Dövizler Tablosu
    /// </summary>
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Döviz kodu (ISO 4217 - TRY, USD, EUR vb.)
        /// </summary>
        public string CurrencyCode { get; set; } = null!;

        /// <summary>
        /// Döviz adı
        /// </summary>
        public string CurrencyName { get; set; } = null!;

        /// <summary>
        /// Döviz sembolü (₺, $, € vb.)
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// Dövizin ait olduğu ülke
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Dövizin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Bilançonun ana para birimi olup olmadığı
        /// </summary>
        public bool IsBaseCurrency { get; set; }

        /// <summary>
        /// Ülkenin resmi para birimi olup olmadığı
        /// </summary>
        public bool IsNationalCurrency { get; set; }

        /// <summary>
        /// Entegrasyon veya harici sistem meta kodu
        /// </summary>
        public string? MetaCode { get; set; }

        /// <summary>
        /// Alış kuru oranı
        /// </summary>
        public decimal BuyRate { get; set; }

        /// <summary>
        /// Satış kuru oranı
        /// </summary>
        public decimal SellRate { get; set; }

        public List<Movements> Movements { get; set; }
        public List<StockType> StockTypes { get; set; }
        public Currency(List<Movements> movements, List<StockType> stockTypes)
        {
            Movements = movements;
            StockTypes = stockTypes;
        }
    }

}
