using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AccountTypeFeature.Command.Create;
using KuyumHesap.Application.Features.AccountTypeFeature.Command.Delete;
using KuyumHesap.Application.Features.AccountTypeFeature.Command.Update;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.AccountTypeCont
{
    public class AccountTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountTypeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{id}")]
        public async Task<ResponseDto<DeleteAccountTypeCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteAccountTypeCommandRequest(id), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateAccountTypeCommandResponse>> CreateAsync(CreateAccountTypeCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateAccountTypeCommandResponse>> UpdateAsync(UpdateAccountTypeCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllAccountTypeQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllAccountTypeQueryRequest(), token);
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdAccountTypeQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdAccountTypeQueryRequest(id), token);
        }
    }
}
