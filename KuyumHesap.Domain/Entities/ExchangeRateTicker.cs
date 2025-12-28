using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// KurKayanYazi (Döviz Kuru Ticker)
    /// </summary>
    public class ExchangeRateTicker : BaseEntity
    {
        /// <summary>
        /// Döviz kodu (ISO 4217 - TRY, USD, EUR vb.)
        /// </summary>
        public string CurrencyCode { get; set; } = null!;

        /// <summary>
        /// Alış kuru
        /// </summary>
        public decimal BuyRate { get; set; }

        /// <summary>
        /// Satış kuru
        /// </summary>
        public decimal SellRate { get; set; }
    }
}
