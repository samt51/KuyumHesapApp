namespace KuyumHesap.Domain.Entities
{
    public class RolePermission : KuyumHesap.Domain.Command.BaseEntity
    {
        public int RoleId { get; set; }
        public Roles Roles { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

    }
}
