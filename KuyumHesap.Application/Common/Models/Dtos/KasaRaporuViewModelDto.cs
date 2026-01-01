using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;

namespace KuyumHesap.Application.Common.Models.Dtos
{
    public class KasaRaporuViewModelDto
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<KasaDetayViewModel> Detaylar { get; set; } = new();
    }
}
