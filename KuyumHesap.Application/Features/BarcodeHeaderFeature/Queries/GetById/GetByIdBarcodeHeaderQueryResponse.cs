using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById
{
    public class GetByIdBarcodeHeaderQueryResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// Barkod başlık adı
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// RFID barkod olup olmadığı bilgisi
        /// </summary>
        public bool IsRfid { get; set; }

        /// <summary>
        /// Barkodun başlangıç genişlik değeri
        /// </summary>
        public decimal StartWidth { get; set; }

        /// <summary>
        /// Barkodun başlangıç yükseklik değeri
        /// </summary>
        public decimal StartHeight { get; set; }
        public List<BarcodeDetailResponseDto> barcodeDetails { get; set; }
    }
}
