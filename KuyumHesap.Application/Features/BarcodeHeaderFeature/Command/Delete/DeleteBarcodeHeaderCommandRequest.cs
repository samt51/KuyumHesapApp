using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Delete
{
    public class DeleteBarcodeHeaderCommandRequest : IRequest<ResponseDto<DeleteBarcodeHeaderCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteBarcodeHeaderCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
