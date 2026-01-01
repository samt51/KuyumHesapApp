namespace KuyumHesap.Application.Common.Models
{
    public class BalanceSummaryDto
    {
        public string DovizKodu { get; set; } = null!;
        public decimal Devreden { get; set; }
        public decimal GunlukGiris { get; set; }
        public decimal GunlukCikis { get; set; }
        public decimal Bakiye { get; set; }
        public decimal HasKarsiligi { get; set; }
    }
}
