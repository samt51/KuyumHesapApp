using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.CureFeature.Commands.ReadyAndUpdate;
using KuyumHesap.Application.Features.CureFeature.Queries.GetLatest;
using KuyumHesap.Application.Features.CureFeature.Queries.GetUpdatedDailyCure;
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
        public async Task<ResponseDto<List<GetLatestQueryResponse>>> GetLatestAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetLatestQueryRequest(), token);
        }
        [HttpGet]
        public async Task<ResponseDto<GetUpdatedDailyCureResponse>> GetLastCureAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetUpdatedDailyCureRequest(), token);

        }
    }
}
