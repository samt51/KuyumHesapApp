using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAllReports
{
    public class GetAllReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<CashRegisterStatusResponse> Detaylar { get; set; } = new();
        public decimal BankBalanceTotal { get; set; }
        public decimal PosBalanceTotal { get; set; }

    }
 
}
