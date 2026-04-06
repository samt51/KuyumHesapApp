using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.Delete
{
    public class DeleteMovementCommandRequest : IRequest<ResponseDto<DeleteMovementCommandResponse>>
    {
        public int MovementId { get; set; }
        public DeleteMovementCommandRequest(int movementId)
        {
            this.MovementId = movementId;
        }
    }
}
