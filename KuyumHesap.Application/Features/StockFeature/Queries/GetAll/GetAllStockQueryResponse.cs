using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Common.Models.Dtos.ResponseDtos;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetAll
{
    public class GetAllStockQueryResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// Stok adı
        /// </summary>
        public string StockName { get; set; } = null!;

        /// <summary>
        /// Stok tipi kimliği (Foreign Key -> StockTypes)
        /// </summary>
        public StockTypeResponseDto stockTypeResponseDto { get; set; }

        /// <summary>
        /// Stok grup kimliği (Foreign Key -> StockGroups)
        /// </summary>
        public StockGroupResponseDto groupResponseDto { get; set; }

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
        /// Stok miktarı
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Stok aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }
    }
}
