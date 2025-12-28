using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Barkod Başlıkları Tablosu
    /// </summary>
    public class BarcodeHeader : BaseEntity
    {
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

       public List<BarcodeDetail> BarcodeDetails { get; set; }

        public BarcodeHeader(List<BarcodeDetail> barcodeDetails)
        {
            BarcodeDetails = barcodeDetails;
        }
    }
}
