namespace KuyumHesap.Application.Common.Models.Dtos
{
    public class KasaDetayViewModelDto
    {
        public string DovizKodu { get; set; } = "";
        public decimal Devreden { get; set; }
        public decimal GunlukGiris { get; set; }
        public decimal GunlukCikis { get; set; }
        public decimal Bakiye { get; set; }
        public decimal HasKarsiligi { get; set; }
    }
}
