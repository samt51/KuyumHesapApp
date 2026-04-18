using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Command.Assign
{
    public class AssignRolePermissionCommandRequest : IRequest<ResponseDto<AssignRolePermissionCommandResponse>>
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
