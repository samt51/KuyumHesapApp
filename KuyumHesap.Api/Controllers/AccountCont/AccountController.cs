using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AccountFeature.Command.Create;
using KuyumHesap.Application.Features.AccountFeature.Command.Delete;
using KuyumHesap.Application.Features.AccountFeature.Command.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.AccountCont
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;   
        }
        [HttpPost]
        public async Task<ResponseDto<CreateAccountCommandResponse>> CreateAsync(CreateAccountCommandRequest request,CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateAccountCommandResponse>> UpdateAsync(UpdateAccountCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteAccountCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteAccountCommandRequest { Id = id }, token);
        }
    }
}
