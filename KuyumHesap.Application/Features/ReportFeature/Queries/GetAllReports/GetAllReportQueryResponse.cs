using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAllReports
{
    public class GetAllReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<KasaDetayViewModel> Detaylar { get; set; } = new();
        public decimal BankBalanceTotal { get; set; }
        public decimal PosBalanceTotal { get; set; }

    }
 
}
