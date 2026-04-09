using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Roles.Update
{
    public class UpdateRolesCommandRequest : IRequest<ResponseDto<UpdateRolesCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
