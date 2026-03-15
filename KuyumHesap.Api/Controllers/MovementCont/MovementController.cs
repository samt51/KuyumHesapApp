using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
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
    }
}
