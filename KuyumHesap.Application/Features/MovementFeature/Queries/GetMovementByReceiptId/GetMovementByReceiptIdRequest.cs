using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetMovementByReceiptId
{
    public class GetMovementByReceiptIdRequest : IRequest<ResponseDto<List<GetMovementByReceiptIdResponse>>>
    {
        public int ReceiptId { get; set; }
        public GetMovementByReceiptIdRequest(int receiptId)
        {
            this.ReceiptId = receiptId;
        }
    }
}
