using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AuthFeature.Commands.Register
{
    public class RegisterCommandRequest : IRequest<ResponseDto<RegisterCommandResponse>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string CompanyCode { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? FisYaziciAdi { get; set; }
        public string? BarkodYaziciAdi { get; set; }
        public string? VarsayilanYaziciAdi { get; set; }
        public bool Active { get; set; } = true;
    }
}
