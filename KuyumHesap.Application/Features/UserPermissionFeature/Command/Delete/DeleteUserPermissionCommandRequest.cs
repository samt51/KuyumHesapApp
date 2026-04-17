using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Command.Delete
{
    public class DeleteUserPermissionCommandRequest : IRequest<ResponseDto<DeleteUserPermissionCommandResponse>>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
