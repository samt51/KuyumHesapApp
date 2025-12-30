using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Create
{
    public class CreateBarcodeHeaderCommandRequest : IRequest<ResponseDto<CreateBarcodeHeaderCommandResponse>>
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
        public List<BarcodeDetailRequestDto> BarcodeDetails { get; set; }

        public CreateBarcodeHeaderCommandRequest(List<BarcodeDetailRequestDto> barcodeDetails)
        {
            BarcodeDetails = barcodeDetails;
        }
    }
}
