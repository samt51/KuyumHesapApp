namespace KuyumHesap.Application.Features.AccountFeature.Queries.CheckUniqueness
{
    public class CheckUniquenessQueryResponse
    {
        public string AccountName { get; set; } = string.Empty;
        public bool isUnique { get; set; }
    }
}
