using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AuthFeature.Commands.Login
{
    public class LoginCommandRequest(string branchCode, string companyCode, string userName, string password) : IRequest<ResponseDto<LoginCommandResponse>>
    {
        public string CompanyCode { get; set; } = branchCode;
        public string BranchCode { get; set; } = companyCode;
        public string UserName { get; } = userName;
        public string Password { get; } = password;
    }
}
