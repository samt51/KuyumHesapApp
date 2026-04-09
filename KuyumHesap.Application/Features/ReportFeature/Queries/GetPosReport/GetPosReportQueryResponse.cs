using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport
{
    public class GetPosReportQueryResponse
    {
        public decimal? TotalHas { get; set; }
        public List<GetPosReportItemResponse> Items { get; set; }
    }
    public class GetPosReportItemResponse
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal TotalHas { get; set; }
        public List<EkstreBakiyeViewModel> DevredenBakiyeler { get; set; } = new();
        public List<EkstreSatirViewModel> Hareketler { get; set; } = new();
    }
}
