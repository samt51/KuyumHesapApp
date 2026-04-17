using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Command.Assign
{
    public class AssignUserPermissionCommandRequest : IRequest<ResponseDto<AssignUserPermissionCommandResponse>>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public bool IsAllowed { get; set; }
    }
}
