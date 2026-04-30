using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.StockFeature.Commands.Create;
using KuyumHesap.Application.Features.StockFeature.Commands.Delete;
using KuyumHesap.Application.Features.StockFeature.Commands.Update;
using KuyumHesap.Application.Features.StockFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockFeature.Queries.GetById;
using KuyumHesap.Application.Features.StockFeature.Queries.GetByGroupId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace KuyumHesap.Api.Controllers.StockCont
{
    public class StockController : BaseController
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public Task<ResponseDto<GetByIdStockQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return _mediator.Send(new GetByIdStockQueryRequest(id), token);
        }
        [HttpGet]
        public Task<ResponseDto<List<GetAllStockQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return _mediator.Send(new GetAllStockQueryRequest(), token);
        }
        [HttpGet("{groupId}")]

        public async Task<ResponseDto<List<GetAllStockQueryResponse>>> GetStockByGroupId(int groupId, CancellationToken token)
        {
            return await _mediator.Send(new GetStockByGroupIdQueryRequest(groupId), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateStockCommandResponse>> CreateAsync(CreateStockCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateStockCommandResponse>> UpdateAsync(UpdateStockCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteStockCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteStockCommandRequest(id), token);
        }
    }
}
