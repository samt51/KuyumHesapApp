using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// STOK GRUPLARI TABLOSU
    /// </summary>
    public class StockGroup : BaseEntity
    {
        public StockGroup()
        {
            
        }
        /// <summary>
        /// Stok grup adı
        /// </summary>
        public string StockGroupName { get; set; } = null!;
        public List<StockType> StockTypes { get; set; }
        public List<Stock> Stocks { get; set; }

        public StockGroup(List<StockType> stockTypes, List<Stock> stocks)
        {
            StockTypes = stockTypes;
            Stocks = stocks;
        }
    }
}
