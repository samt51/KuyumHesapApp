using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Create
{
    public class CreatePermissionCommandRequest : IRequest<ResponseDto<CreatePermissionCommandResponse>>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
