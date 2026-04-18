using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.RolePermissionFeature.Command.Assign;
using KuyumHesap.Application.Features.RolePermissionFeature.Command.Delete;
using KuyumHesap.Application.Features.RolePermissionFeature.Queries.GetByRoleId;
using KuyumHesap.Application.Features.UserFeature.Commands.Roles.Create;
using KuyumHesap.Application.Features.UserFeature.Commands.Roles.Update;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.RoleCont
{
    public class RoleController : BaseController
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<GetAllRolesQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllRolesQueryRequest(), token);
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdRolesQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdRolesQueryRequest(id), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreateRolesCommandResponse>> CreateAsync(CreateRolesCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpPut]
        public async Task<ResponseDto<UpdateRolesCommandResponse>> UpdateAsync(UpdateRolesCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpGet("{roleId}")]
        public async Task<ResponseDto<List<GetRolePermissionsQueryResponse>>> GetPermissionsAsync(int roleId, CancellationToken token)
        {
            return await _mediator.Send(new GetRolePermissionsQueryRequest(roleId), token);
        }

        [HttpPost]
        public async Task<ResponseDto<AssignRolePermissionCommandResponse>> AssignPermissionAsync(AssignRolePermissionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpDelete]
        public async Task<ResponseDto<DeleteRolePermissionCommandResponse>> DeletePermissionAsync([FromQuery] int roleId, [FromQuery] int permissionId, CancellationToken token)
        {
            return await _mediator.Send(new DeleteRolePermissionCommandRequest
            {
                RoleId = roleId,
                PermissionId = permissionId
            }, token);
        }
    }
}
