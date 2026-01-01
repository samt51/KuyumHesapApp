using KuyumHesap.Application.Common.Models.Dtos;

namespace KuyumHesap.Application.Features.StockTypeFeature.Queries.GetAll
{
    public class GetAllStockTypeQueryResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// Stok tipi adı
        /// </summary>
        public string StockTypeName { get; set; } = null!;

        /// <summary>
        /// Bağlı olduğu stok grup kimliği (Foreign Key -> StockGroups)
        /// </summary>
        public StockGroupResponseDto StockGroup { get; set; }

        /// <summary>
        /// Stok tipine bağlı döviz kimliği (Foreign Key -> Currencies)
        /// </summary>
        public int CurrencyId { get; set; }
        public CurrencyResponseDto Currency { get; set; }

        /// <summary>
        /// Stok tipinin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }
    }
}
