using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// Rol Tablosu
    /// </summary>
    public class Roles : BaseEntity
    {
        public Roles()
        {
            
        }
        /// <summary>
        /// Role Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Role Kodu
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// Role Type
        /// </summary>
        public string Type { get; set; } = string.Empty;
        public List<Users> Users { get; set; }

        public Roles(List<Users> users)
        {
            Users = users;
        }
    }
}
