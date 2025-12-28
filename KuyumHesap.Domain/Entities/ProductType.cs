using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Ürün Türleri
    /// </summary>
    public class ProductType : BaseEntity
    {
        /// <summary>
        /// Ürün tipi adı
        /// </summary>
        public string ProductTypeName { get; set; } = null!;
    }
}
