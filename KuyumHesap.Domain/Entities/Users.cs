using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Kullanıcı Tablosu
    /// </summary>
    public class Users : BaseEntity
    {
        public Users()
        {

        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }
        public int? BagliHesapID { get; set; }
        public string? BarkodYaziciAdi { get; set; }
        public string? FisYaziciAdi { get; set; }
        public string? VarsayilanYaziciAdi { get; set; }
        public List<TaskItem> AssignedTasks { get; set; }
        public List<TaskItem> CreatedTasks { get; set; }
        public Users(List<TaskItem> askItems, List<TaskItem> bskItems)
        {
            AssignedTasks = askItems;
            CreatedTasks = bskItems;
        }
    }
}
