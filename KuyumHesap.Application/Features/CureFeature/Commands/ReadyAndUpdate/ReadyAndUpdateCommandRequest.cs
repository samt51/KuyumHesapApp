using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Commands.ReadyAndUpdate
{
    public class ReadyAndUpdateCommandRequest : IRequest<ResponseDto<ReadyAndUpdateCommandResponse>>
    {

    }
}
