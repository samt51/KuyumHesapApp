using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Command.DeleteAllSystem
{
    public class DeleteAllSystemCommandRequest:IRequest<ResponseDto<DeleteAllSystemCommandResponse>>
    {
    }
}
