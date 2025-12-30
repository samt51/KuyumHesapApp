using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Stoklar Tablosu
    /// </summary>
    public class Stock : BaseEntity
    {
        public Stock()
        {

        }
        /// <summary>
        /// Stok adı
        /// </summary>
        public string StockName { get; set; } = null!;

        /// <summary>
        /// Stok tipi kimliği (Foreign Key -> StockTypes)
        /// </summary>
        public int StockTypeId { get; set; }
        public StockType StockType { get; set; }

        /// <summary>
        /// Stok grup kimliği (Foreign Key -> StockGroups)
        /// </summary>
        public int GroupId { get; set; }
        public StockGroup StockGroup { get; set; }

        /// <summary>
        /// Stok birimi adı (adet, gram, kg vb.)
        /// </summary>
        public string UnitName { get; set; } = null!;

        /// <summary>
        /// Stok birimi kimliği
        /// </summary>
        public int StockUnitId { get; set; }

        /// <summary>
        /// İşçilik birimi kimliği
        /// </summary>
        public int LaborUnitId { get; set; }

        /// <summary>
        /// Ürünün milyem değeri
        /// </summary>
        public decimal MillRate { get; set; }

        /// <summary>
        /// Stok aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }

        public List<Movements> Movements { get; set; }

        public Stock(List<Movements> movements)
        {
            Movements = movements;
        }
    }

}
