using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Command.Create
{
    public class CreateSettingCommandRequest : IRequest<ResponseDto<CreateSettingCommandResponse>>
    {
        public string Key { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
