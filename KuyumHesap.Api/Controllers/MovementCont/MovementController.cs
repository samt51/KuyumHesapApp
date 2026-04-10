using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.MovementFeature.Commands.Delete;
using KuyumHesap.Application.Features.MovementFeature.Commands.MutabakatUpdate;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetMovementByReceiptId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.MovementCont
{

    public class MovementController : BaseController
    {
        private readonly IMediator _mediator;
        public MovementController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{receiptId}")]
        public async Task<ResponseDto<List<GetMovementByReceiptIdResponse>>> GetMovementByReceiptIdAsync(int receiptId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetMovementByReceiptIdRequest(receiptId), cancellationToken);
        }
        [HttpDelete("{movementId}")]
        public async Task<ResponseDto<DeleteMovementCommandResponse>> DeleteAsync(int receiptId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteMovementCommandRequest(receiptId), cancellationToken);
        }
        [HttpPost]
        public async Task<ResponseDto<MutabakatUpdateCommandResponse>> UpdateMutabakat([FromBody] MutabakatUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
