using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.UserFeature.Commands.Create;
using KuyumHesap.Application.Features.UserFeature.Commands.Update;
using KuyumHesap.Application.Features.UserFeature.Queries.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.UsersCont
{
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllUserQueryResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllUserQueryRequest(), cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdUserQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdUserQueryRequest(id), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateUserCommandResponse>> CreateAsync(CreateUserCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPut]
        public async Task<ResponseDto<UpdateUserCommandResponse>> UpdateAsync(UpdateUserCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
