namespace KuyumHesap.Application.Features.RolePermissionFeature.Queries.GetByRoleId
{
    public class GetRolePermissionsQueryResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionCode { get; set; } = string.Empty;
        public string PermissionName { get; set; } = string.Empty;
    }
}
