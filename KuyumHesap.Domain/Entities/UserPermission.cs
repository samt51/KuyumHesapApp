namespace KuyumHesap.Domain.Entities
{
    public class UserPermission
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public bool IsAllowed { get; set; }
    }
}
