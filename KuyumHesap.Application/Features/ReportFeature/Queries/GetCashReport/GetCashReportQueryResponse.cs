using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryResponse
    {
        public decimal? TotalHas { get; set; }
        public List<GetCashReportItemResponse> Items { get; set; }

    }
    public class GetCashReportItemResponse
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal TotalHas { get; set; }
        public List<EkstreBakiyeViewModel> DevredenBakiyeler { get; set; } = new();
        public List<EkstreSatirViewModel> Hareketler { get; set; } = new();
    }

}
