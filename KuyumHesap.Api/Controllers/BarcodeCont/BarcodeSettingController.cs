using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetById;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Create;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Delete;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Update;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.BarcodeCont
{
    public class BarcodeSettingController : BaseController
    {
        private readonly IMediator _mediator;
        public BarcodeSettingController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdAccountQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdAccountQueryRequest(id), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllBarcodeHeaderQueryRequest(), token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteBarcodeHeaderCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteBarcodeHeaderCommandRequest(id), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateBarcodeHeaderCommandResponse>> CreateAsync(CreateBarcodeHeaderCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateBarcodeHeaderCommandResponse>> UpdateAsync(UpdateBarcodeHeaderCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
