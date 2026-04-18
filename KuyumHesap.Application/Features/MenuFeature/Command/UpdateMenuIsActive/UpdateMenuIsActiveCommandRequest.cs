using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.UpdateMenuIsActive
{
    public class UpdateMenuIsActiveCommandRequest : IRequest<ResponseDto<UpdateMenuIsActiveCommandResponse>>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
