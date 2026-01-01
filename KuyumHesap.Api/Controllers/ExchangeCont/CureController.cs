using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.CureFeature.Commands.ReadyAndUpdate;
using KuyumHesap.Application.Features.CureFeature.Queries.GetLatest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ExchangeCont
{
    public class CureController : BaseController
    {
        private readonly IMediator _mediator;
        public CureController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<ReadyAndUpdateCommandResponse>> ReadyAndUpdateAsync(ReadyAndUpdateCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetLatestQueryResponse>>> GetLatest(CancellationToken token)
        {
            return await _mediator.Send(new GetLatestQueryRequest(), token);
        }

    }
}
