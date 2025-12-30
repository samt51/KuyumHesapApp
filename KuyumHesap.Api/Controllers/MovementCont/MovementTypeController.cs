using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetAll;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.MovementCont
{
    public class MovementTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public MovementTypeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllMovementTypeQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllMovementTypeQueryRequest(), token);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdMovementTypeQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdMovementTypeQueryRequest(id), token);
        }
    }
}
