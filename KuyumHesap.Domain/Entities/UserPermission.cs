namespace KuyumHesap.Domain.Entities
{
    public class UserPermission : KuyumHesap.Domain.Command.BaseEntity
    {
        public int UserId { get; set; }
        public Users Users { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public bool IsAllowed { get; set; }
    }
}
