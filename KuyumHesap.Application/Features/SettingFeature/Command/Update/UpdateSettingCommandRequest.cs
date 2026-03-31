using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Command.Update
{
    public class UpdateSettingCommandRequest : IRequest<ResponseDto<UpdateSettingCommandResponse>>
    {
        public List<SettingUpdateDto> Settings { get; set; } = new();
    }

    public class SettingUpdateDto
    {
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}
