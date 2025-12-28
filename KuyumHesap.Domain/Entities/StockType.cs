using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// STOK TİPLERİ TABLOSU
    /// </summary>
    public class StockType : BaseEntity
    {

        /// <summary>
        /// Stok tipi adı
        /// </summary>
        public string StockTypeName { get; set; } = null!;

        /// <summary>
        /// Bağlı olduğu stok grup kimliği (Foreign Key -> StockGroups)
        /// </summary>
        public int StockGroupId { get; set; }
        public required StockGroup StockGroup { get; set; }

        /// <summary>
        /// Stok tipine bağlı döviz kimliği (Foreign Key -> Currencies)
        /// </summary>
        public int CurrencyId { get; set; }
        public required Currency Currency { get; set; }

        /// <summary>
        /// Stok tipinin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }
        public List<Stock> Stocks { get; set; }

        public StockType(List<Stock> stocks)
        {
            Stocks = stocks;
        }
    }
}
