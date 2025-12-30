using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Delete
{
    public class DeleteReceiptCommandRequest : IRequest<ResponseDto<DeleteReceiptCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteReceiptCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
