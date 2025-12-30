using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
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
        [Route("GetStokGruplari")]
        public async Task<ResponseDto<List<GetStockGroupQueryResponse>>> GetStockGroupAsync(GetStockGroupQueryRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpGet]
        [Route("GetStokTipleri")]
        public async Task<ResponseDto<List<GetStockTypeQueryResponse>>> GetStockTypeAsync(int stokGrupID, CancellationToken token)
        {
            return await _mediator.Send(new GetStockTypeQueryRequest(stokGrupID), token);
        }
        [HttpGet]
        [Route("GetStoklar")]
        public async Task<ResponseDto<List<GetStockQueryResponse>>> GetStockAsync(int stokTipID, CancellationToken token)
        {
            return await _mediator.Send(new GetStockQueryRequest(stokTipID), token);
        }
        [HttpGet]
        [Route("GetUrunTipleri")]
        public async Task<ResponseDto<List<GetProductTypeQueryResponse>>> GetProductTypeAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetProductTypeQueryRequest(), token);
        }
        [HttpGet]
        [Route("GetToptancilar")]
        public async Task<ResponseDto<List<GetPackerQueryResponse>>> GetPackerAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetPackerQueryRequest(), token);
        }
        [HttpGet]
        [Route("GetStokBilgisi")]
        public async Task<ResponseDto<GetStockInfoQueryResponse>> GetStockInfoAsync(int stockId, CancellationToken token)
        {
            return await _mediator.Send(new GetStockInfoQueryRequest(stockId), token);
        }
    }
}
