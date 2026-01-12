using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetAllMain;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockInfo;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.BarcodeCont
{
    public class BarcodeController : BaseController
    {
        private readonly IMediator _mediator;
        public BarcodeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]

        public async Task<ResponseDto<List<GetStockGroupQueryResponse>>> GetStockGroupAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetStockGroupQueryRequest(), token);
        }
        [HttpGet]
      
        public async Task<ResponseDto<List<GetStockTypeQueryResponse>>> GetStockTypeAsync(List<int> stokGrupIDs, CancellationToken token)
        {
            return await _mediator.Send(new GetStockTypeQueryRequest(stokGrupIDs), token);
        }
        [HttpGet]

        public async Task<ResponseDto<List<GetStockQueryResponse>>> GetStockAsync(List<int> stokTipID, CancellationToken token)
        {
            return await _mediator.Send(new GetStockQueryRequest(stokTipID), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetProductTypeQueryResponse>>> GetProductTypeAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetProductTypeQueryRequest(), token);
        }
        [HttpGet]

        public async Task<ResponseDto<List<GetPackerQueryResponse>>> GetPackerAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetPackerQueryRequest(), token);
        }
        [HttpGet]

        public async Task<ResponseDto<GetStockInfoQueryResponse>> GetStockInfoAsync(int stockId, CancellationToken token)
        {
            return await _mediator.Send(new GetStockInfoQueryRequest(stockId), token);
        }
        [HttpGet]
      
        public async Task<ResponseDto<GetAllMainQueryResponse>> GetAllMainBarcodeAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllMainQueryRequest(), token);
        }
    }
}
