using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AccountFeature.Command.Create;
using KuyumHesap.Application.Features.AccountFeature.Command.Delete;
using KuyumHesap.Application.Features.AccountFeature.Command.Update;
using KuyumHesap.Application.Features.AccountFeature.Queries.CheckSoftDuplicate;
using KuyumHesap.Application.Features.AccountFeature.Queries.CheckUniqueness;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetById;
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
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdAccountQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdAccountQueryRequest(id), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllAccountQueryResponse>>> GetAllAsync([FromQuery] string accountTypeName, CancellationToken token)
        {
            return await _mediator.Send(new GetAllAccountQueryRequest { AccountTypeName = accountTypeName }, token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateAccountCommandResponse>> CreateAsync(CreateAccountCommandRequest request, CancellationToken token)
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
        [HttpGet("check-uniqueness")]
        public async Task<ResponseDto<CheckUniquenessQueryResponse>> CheckUniquenessAsync(string type, string value, int currentId, CancellationToken token)
        {
            return await _mediator.Send(new CheckUniquenessQueryRequest { Type = type, Value = value, CurrentId = currentId }, token);
        }

        [HttpGet("check-soft-duplicate")]
        public async Task<ResponseDto<CheckSoftDuplicateQueryResponse>> CheckSoftDuplicate(string accountName, int currentId = 0)
        {
            return await _mediator.Send(new CheckSoftDuplicateQueryRequest { AccountName = accountName, CurrentId = currentId });
        }
    }
}
