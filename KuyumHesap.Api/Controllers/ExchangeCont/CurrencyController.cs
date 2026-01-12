using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.CurrecyFeature.Commands.Create;
using KuyumHesap.Application.Features.CurrecyFeature.Commands.Update;
using KuyumHesap.Application.Features.CurrecyFeature.Queries.GetAll;
using KuyumHesap.Application.Features.CurrecyFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ExchangeCont
{

    public class CurrencyController : BaseController
    {
        private readonly IMediator _mediator;
        public CurrencyController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllCurrencyQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllCurrencyQueryRequest(), token);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdCurrencyQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdCurrencyQueryRequest(id), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateCurrencyCommandResponse>> CreateAsync(CreateCurrencyCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPut]
        public async Task<ResponseDto<UpdateCurrencyCommandResponse>> UpdateAsync(UpdateCurrencyCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
