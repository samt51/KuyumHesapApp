namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock
{
    public class GetStockQueryResponse
    {
        public int Id { get; set; }
        public string StockName { get; set; } = string.Empty;
        public decimal MillRate { get; set; }
        public string UnitName { get; set; } = string.Empty;
    }
}
