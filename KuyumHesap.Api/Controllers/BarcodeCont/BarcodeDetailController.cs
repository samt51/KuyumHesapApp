using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeDetailFeature.Command.Create;
using KuyumHesap.Application.Features.BarcodeDetailFeature.Command.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.BarcodeCont
{
    public class BarcodeDetailController : BaseController
    {
        private readonly IMediator _mediator;
        public BarcodeDetailController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<CreateBarcodeDetailCommandResponse>> CreateAsync(CreateBarcodeDetailCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateBarcodeDetailCommandResponse>> UpdateAsync(UpdateBarcodeDetailCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
