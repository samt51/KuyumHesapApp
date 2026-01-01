using Azure.Core;
using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.StockGroupFeature.Commands.Create;
using KuyumHesap.Application.Features.StockGroupFeature.Commands.Delete;
using KuyumHesap.Application.Features.StockGroupFeature.Commands.Update;
using KuyumHesap.Application.Features.StockGroupFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockGroupFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.StockCont
{

    public class StockGroupController : BaseController
    {
        private readonly IMediator _mediator;
        public StockGroupController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public Task<ResponseDto<List<GetAllStockGroupQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return _mediator.Send(new GetAllStockGroupQueryRequest(), token);
        }
        [HttpGet("{id}")]
        public Task<ResponseDto<GetByIdStockGroupQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return _mediator.Send(new GetByIdStockGroupQueryRequest(id), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreateStockGroupCommandResponse>> CreateAsync(CreateStockGroupCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateStockGroupCommandResponse>> UpdateAsync(UpdateStockGroupCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteStockGroupCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteStockGroupCommandRequest(id), token);
        }
    }
}
