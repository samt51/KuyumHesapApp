namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAll
{
    public class GetAllMenuQueryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public string? RequeiredPermissionCode { get; set; }
        public List<GetAllMenuQueryResponse> Children { get; set; } = new();
    }
}
