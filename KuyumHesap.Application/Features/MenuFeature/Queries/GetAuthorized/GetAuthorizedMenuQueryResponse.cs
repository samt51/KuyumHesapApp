namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAuthorized
{
    public class GetAuthorizedMenuQueryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int OrderNo { get; set; }
        public string? RequeiredPermissionCode { get; set; }
        public List<GetAuthorizedMenuQueryResponse> Children { get; set; } = new();
    }
}
