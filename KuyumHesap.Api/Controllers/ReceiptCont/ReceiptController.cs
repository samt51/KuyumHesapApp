using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.Create;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.Delete;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.Update;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.UpdateAgreement;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ReceiptCont
{
    public class ReceiptController : BaseController
    {
        private readonly IMediator _mediator;
        public ReceiptController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{isCari}")]
        public Task<ResponseDto<List<GetAllReceiptQueryResponse>>> GetAllAsync(bool isCari, CancellationToken token)
        {
            return _mediator.Send(new GetAllReceiptQueryRequest { IsCari = isCari }, token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateReceiptCommandResponse>> CreateAsync(CreateReceiptCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateReceiptCommandResponse>> UpdateAsync(UpdateReceiptCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPut("hareketler/mutabakat")]
        public async Task<ResponseDto<UpdateAgreementCommandResponse>> UpdateAgreementAsync(UpdateAgreementCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteReceiptCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteReceiptCommandRequest(id), token);
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdReceiptQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdReceiptQueryRequest(id), token);
        }
    }
}
