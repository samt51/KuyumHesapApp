using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport
{
    public class GetPosReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<KasaDetayViewModel> Detaylar { get; set; } = new();
    }
}
