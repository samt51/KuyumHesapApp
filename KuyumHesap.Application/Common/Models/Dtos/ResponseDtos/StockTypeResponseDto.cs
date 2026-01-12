namespace KuyumHesap.Application.Common.Models.Dtos.ResponseDtos
{
    public class StockTypeResponseDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Stok tipi adı
        /// </summary>
        public string StockTypeName { get; set; } = null!;

        /// <summary>
        /// Bağlı olduğu stok grup kimliği (Foreign Key -> StockGroups)
        /// </summary>
        public StockGroupsResponseDto stockGroupsResponseDto { get; set; }
        /// <summary>
        /// Stok tipine bağlı döviz kimliği (Foreign Key -> Currencies)
        /// </summary>
        public CurrencyResponseDto currencyResponseDto { get; set; }

        /// <summary>
        /// Stok tipinin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }
    }
}
