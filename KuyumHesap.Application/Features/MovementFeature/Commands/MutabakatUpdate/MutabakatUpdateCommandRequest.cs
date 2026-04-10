using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.MutabakatUpdate
{
    public class MutabakatUpdateCommandRequest : IRequest<ResponseDto<MutabakatUpdateCommandResponse>>
    {
        public int MovementId { get; set; }
        public bool? IsReconciled { get; set; }
    }
}
