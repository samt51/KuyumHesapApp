using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// DÖVİZ KURLARI
    /// </summary>
    public class ExchangeRate : BaseEntity
    {
        public ExchangeRate()
        {

        }
        public ExchangeRate(DateTime rateDate, int currrencyId,  decimal sellRate, decimal buyRATE, decimal? previosCloseRate)
        {
            this.RateDate = rateDate;
            this.CurrencyId = currrencyId;
            this.BuyRate = buyRATE;
            this.SellRate = sellRate;
            this.PreviousCloseRate = previosCloseRate;
        }
        /// <summary>
        /// Kurun geçerli olduğu tarih
        /// </summary>
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Döviz kuru kimliği
        /// </summary>
        /// 
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        /// <summary>
        /// Alış kuru
        /// </summary>
        public decimal BuyRate { get; set; }

        /// <summary>
        /// Satış kuru
        /// </summary>
        public decimal SellRate { get; set; }

        /// <summary>
        /// Bir önceki günün kapanış kuru
        /// </summary>
        public decimal? PreviousCloseRate { get; set; }
    }
}
