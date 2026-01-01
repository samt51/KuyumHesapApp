using KuyumHesap.Domain.Entities.VwModels;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAccountStatement
{
    public class GetAccountStatementQueryResponse
    {
        public List<EkstreBakiyeViewModel> DevredenBakiyeler { get; set; } = new();
        public List<EkstreSatirViewModel> Hareketler { get; set; } = new();
    }
    public class EkstreBakiyeViewModel
    {
        public string DovizKodu { get; set; } = "";
        public decimal Bakiye { get; set; }
    }
   
}
