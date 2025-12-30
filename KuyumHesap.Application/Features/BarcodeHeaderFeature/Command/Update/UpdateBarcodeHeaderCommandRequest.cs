using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Update
{
    public class UpdateBarcodeHeaderCommandRequest : IRequest<ResponseDto<UpdateBarcodeHeaderCommandResponse>>
    {
        /// <summary>
        /// Entitylerdeki Ortak Id alanı
        /// </summary>
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

        public List<BarcodeDetailRequestDto> barcodeDetails { get; set; }

        public UpdateBarcodeHeaderCommandRequest(List<BarcodeDetailRequestDto> barcodeDetails)
        {
            this.barcodeDetails = barcodeDetails;
        }
    }
}
