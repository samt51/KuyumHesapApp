using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport
{
    public class GetPosReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<CashRegisterStatusResponse> Detaylar { get; set; } = new();
    }
}
