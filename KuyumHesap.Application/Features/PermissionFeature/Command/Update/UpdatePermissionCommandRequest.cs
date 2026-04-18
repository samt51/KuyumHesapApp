using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Update
{
    public class UpdatePermissionCommandRequest : IRequest<ResponseDto<UpdatePermissionCommandResponse>>
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
