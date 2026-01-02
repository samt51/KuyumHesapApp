namespace KuyumHesap.Application.Common.Models.Dtos
{
    public class LoginCommandResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpireDate { get; set; }
    }
}
