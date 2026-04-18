using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Update
{
    public class UpdateUserCommandRequest : IRequest<ResponseDto<UpdateUserCommandResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string CompanyCode { get; set; }
        public string BranchCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }
        public int? BagliHesapID { get; set; }
        public string? BarkodYaziciAdi { get; set; }
        public string? FisYaziciAdi { get; set; }
        public string? VarsayilanYaziciAdi { get; set; }
    }
}
