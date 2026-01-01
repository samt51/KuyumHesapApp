using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport
{
    public class GetBankReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<KasaDetayViewModel> Detaylar { get; set; } = new();
    }
}
