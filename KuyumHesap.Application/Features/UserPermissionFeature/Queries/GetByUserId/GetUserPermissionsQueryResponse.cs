namespace KuyumHesap.Application.Features.UserPermissionFeature.Queries.GetByUserId
{
    public class GetUserPermissionsQueryResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionCode { get; set; } = string.Empty;
        public string PermissionName { get; set; } = string.Empty;
        public bool IsAllowed { get; set; }
    }
}
