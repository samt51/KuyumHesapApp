using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Roles.Create
{
    public class CreateRolesCommandRequest : IRequest<ResponseDto<CreateRolesCommandResponse>>
    {
        public string Name { get; set; }
    }
}
