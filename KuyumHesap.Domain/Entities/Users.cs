using KuyumHesap.Domain.Command;
using System.Data;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Kullanıcı Tablosu
    /// </summary>
    public class Users : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public required Roles Role { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }
        public int? BagliHesapID { get; set; }
        public string? BarkodYaziciAdi { get; set; }
        public string? FisYaziciAdi { get; set; }
        public string? VarsayilanYaziciAdi { get; set; }
    }
}
