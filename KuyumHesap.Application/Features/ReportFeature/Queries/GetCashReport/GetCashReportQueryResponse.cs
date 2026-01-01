namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryResponse
    {
        public decimal ToplamBakiyeHas { get; set; }
        public List<KasaDetayViewModel> Detaylar { get; set; } = new();
    }
    public class KasaDetayViewModel
    {
        public string DovizKodu { get; set; } = "";
        public decimal Devreden { get; set; }
        public decimal GunlukGiris { get; set; }
        public decimal GunlukCikis { get; set; }
        public decimal Bakiye { get; set; }
        public decimal HasKarsiligi { get; set; }
    }
}
