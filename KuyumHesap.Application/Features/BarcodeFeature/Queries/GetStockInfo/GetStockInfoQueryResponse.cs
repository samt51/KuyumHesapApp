namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockInfo
{
    public class GetStockInfoQueryResponse
    {
        public int Id { get; set; }
        public string StockName { get; set; } = null!;
        public string UnitName { get; set; } = null!;
        public decimal MillRate { get; set; }
        public decimal Quantity { get; set; }
        public decimal LaborCost { get; set; }
    }
}
