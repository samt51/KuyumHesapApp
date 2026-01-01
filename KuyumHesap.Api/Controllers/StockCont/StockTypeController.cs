using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.StockFeature.Commands.Delete;
using KuyumHesap.Application.Features.StockTypeFeature.Commands.Create;
using KuyumHesap.Application.Features.StockTypeFeature.Commands.Update;
using KuyumHesap.Application.Features.StockTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockTypeFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.StockCont
{
    public class StockTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public StockTypeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public Task<ResponseDto<GetByIdStockTypeQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return _mediator.Send(new GetByIdStockTypeQueryRequest(id), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllStockTypeQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllStockTypeQueryRequest(), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateStockTypeCommandResponse>> CreateAsync(CreateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateStockTypeCommandResponse>> CreateAsync(UpdateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
        [HttpDelete("{id}")]
        public Task<ResponseDto<DeleteStockCommandResponse>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new DeleteStockCommandRequest(id), cancellationToken);
        }
    }
}
