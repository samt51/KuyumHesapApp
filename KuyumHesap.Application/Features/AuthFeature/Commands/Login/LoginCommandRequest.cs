using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AuthFeature.Commands.Login
{
    public class LoginCommandRequest(string email, string password) : IRequest<ResponseDto<LoginCommandResponse>>
    {
        public string Email { get; } = email;
        public string Password { get; } = password;
    }
}
