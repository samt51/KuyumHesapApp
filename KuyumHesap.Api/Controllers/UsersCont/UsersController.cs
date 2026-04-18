using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.UserFeature.Commands.Create;
using KuyumHesap.Application.Features.UserFeature.Commands.Roles.Create;
using KuyumHesap.Application.Features.UserFeature.Commands.Roles.Update;
using KuyumHesap.Application.Features.UserFeature.Commands.Update;
using KuyumHesap.Application.Features.UserFeature.Queries.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.GetById;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetById;
using KuyumHesap.Application.Features.UserPermissionFeature.Command.Assign;
using KuyumHesap.Application.Features.UserPermissionFeature.Command.Delete;
using KuyumHesap.Application.Features.UserPermissionFeature.Queries.GetByUserId;
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


        [HttpGet]
        public async Task<ResponseDto<List<GetAllRolesQueryResponse>>> GetAllRolesAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllRolesQueryRequest(), cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdRolesQueryResponse>> GetByIdRoleAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdRolesQueryRequest(id), token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateRolesCommandResponse>> CreateRoleAsync(CreateRolesCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPut]
        public async Task<ResponseDto<UpdateRolesCommandResponse>> UpdateRoleAsync(UpdateRolesCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpGet("{userId}")]
        public async Task<ResponseDto<List<GetUserPermissionsQueryResponse>>> GetPermissionsAsync(int userId, CancellationToken token)
        {
            return await _mediator.Send(new GetUserPermissionsQueryRequest(userId), token);
        }

        [HttpPost]
        public async Task<ResponseDto<AssignUserPermissionCommandResponse>> AssignPermissionAsync(AssignUserPermissionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpDelete]
        public async Task<ResponseDto<DeleteUserPermissionCommandResponse>> DeletePermissionAsync([FromQuery] int userId, [FromQuery] int permissionId, CancellationToken token)
        {
            return await _mediator.Send(new DeleteUserPermissionCommandRequest
            {
                UserId = userId,
                PermissionId = permissionId
            }, token);
        }

    }
}
