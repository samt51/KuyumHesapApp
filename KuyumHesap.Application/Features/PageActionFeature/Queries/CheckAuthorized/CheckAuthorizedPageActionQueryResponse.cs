namespace KuyumHesap.Application.Features.PageActionFeature.Queries.CheckAuthorized
{
    public class CheckAuthorizedPageActionQueryResponse
    {
        public bool IsAuthorized { get; set; }
        public string PageCode { get; set; } = string.Empty;
        public string ActionCode { get; set; } = string.Empty;
        public string RequiredPermissionCode { get; set; } = string.Empty;
    }
}
