using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Code { get; set; }//AccountType_Permission
        public string Name { get; set; }// Hesap Tanımlama

        public List<UserPermission> UserPermissions { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
