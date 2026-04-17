using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Delete
{
    public class DeletePermissionCommandRequest : IRequest<ResponseDto<DeletePermissionCommandResponse>>
    {
        public int Id { get; set; }

        public DeletePermissionCommandRequest(int id)
        {
            Id = id;
        }
    }
}
