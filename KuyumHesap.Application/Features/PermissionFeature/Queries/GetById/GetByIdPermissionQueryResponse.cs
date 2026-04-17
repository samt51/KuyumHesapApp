namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetById
{
    public class GetByIdPermissionQueryResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
