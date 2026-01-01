using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Commands.Update
{
    public class UpdateCureCommandRequest : IRequest<ResponseDto<UpdateCureCommandResponse>>
    {
    }
}
