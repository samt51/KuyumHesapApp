namespace KuyumHesap.Application.Features.CureFeature.Queries.GetLatest
{
    public class GetLatestQueryResponse
    {
        public int Id { get; set; }
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
        /// <summary>
        /// Önceki Kapanış Kuru
        /// </summary>       
        public decimal PreviousClosingRate { get; set; }
    }
}
