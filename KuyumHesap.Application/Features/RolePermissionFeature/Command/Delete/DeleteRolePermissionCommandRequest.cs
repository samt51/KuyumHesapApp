using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Command.Delete
{
    public class DeleteRolePermissionCommandRequest : IRequest<ResponseDto<DeleteRolePermissionCommandResponse>>
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
