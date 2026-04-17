using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.PermissionFeature.Command.Create;
using KuyumHesap.Application.Features.PermissionFeature.Command.Delete;
using KuyumHesap.Application.Features.PermissionFeature.Command.Update;
using KuyumHesap.Application.Features.PermissionFeature.Queries.GetAll;
using KuyumHesap.Application.Features.PermissionFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.PermissionCont
{
    public class PermissionController : BaseController
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<GetAllPermissionQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllPermissionQueryRequest(), token);
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdPermissionQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdPermissionQueryRequest(id), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreatePermissionCommandResponse>> CreateAsync(CreatePermissionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpPut]
        public async Task<ResponseDto<UpdatePermissionCommandResponse>> UpdateAsync(UpdatePermissionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeletePermissionCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeletePermissionCommandRequest(id), token);
        }
    }
}
