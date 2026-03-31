using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ExchangeFeature.Commands.Create;
using KuyumHesap.Application.Features.ExchangeFeature.Commands.Delete;
using KuyumHesap.Application.Features.ExchangeFeature.Commands.Update;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetById;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetExchangeRateByCurrencyCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ExchangeCont
{
    public class ExchangeController : BaseController
    {
        private readonly IMediator _mediator;
        public ExchangeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdExchangeQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdExchangeQueryRequest(id), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllExchangeQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllExchangeQueryRequest(), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateExchangeCommandResponse>> CreateAsync(CreateExchangeCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateExchangeCommandResponse>> UpdateAsync(UpdateExchangeCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteExchangeCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteExchangeCommandRequest(id), token);
        }
        [HttpGet("{currencyId}/{isEntry}")]
        public Task<ResponseDto<GetExchangeRateByCurrencyCodeResponse>> GetExchangeRateByCurrencyCodeAsync(int currencyId, bool isEntry,CancellationToken token)
        {
            return _mediator.Send(new GetExchangeRateByCurrencyCodeRequest { CurrencyId = currencyId,IsEntry=isEntry }, token);
        }
    }
}
