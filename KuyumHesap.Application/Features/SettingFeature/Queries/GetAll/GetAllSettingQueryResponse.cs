namespace KuyumHesap.Application.Features.SettingFeature.Queries.GetAll
{
    public class GetAllSettingQueryResponse
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
