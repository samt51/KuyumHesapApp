using KuyumHesap.Domain.Command;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Domain.Entities.VwModels
{
    [Keyless]
    public class EkstreSatirViewModel : IBaseEntity
    {
        public int HareketID { get; set; }
        public int FisID { get; set; }
        public int HesapID { get; set; }
        public int HareketTipID { get; set; }
        public int? KarsiHareketID { get; set; }
        public DateTime Tarih { get; set; }
        public string Islem { get; set; } = "";
        public string? Aciklama { get; set; }
        public bool GirisMi { get; set; }
        public decimal Miktar { get; set; }
        public string Birim { get; set; } = "";
        public decimal Kur { get; set; }
        public decimal? KarsilikMiktar { get; set; }
        public string? KarsilikBirim { get; set; }
        public decimal? KarsilikKuru { get; set; }
        public decimal EskiBakiye { get; set; } // Bu alan RaporServisi tarafından doldurulacak.
        public decimal SonBakiye { get; set; } // Bu alan RaporServisi tarafından doldurulacak.
        public int? StokID { get; set; }
        public string? StokAdi { get; set; }
        public decimal? Milyem { get; set; }
        public decimal? Iscilik { get; set; }
        public string? IscBrm { get; set; }
        public int? IscAdet { get; set; }
        public bool IscDahil { get; set; }
        public bool Mutabakat { get; set; }
        public decimal? UrunHasDegeri { get; set; }
        public decimal? ToplamIscilik { get; set; }
        public decimal BakiyeEtkiMiktari { get; set; }
        public string BakiyeBirimi { get; set; } = "";
        public decimal Tutar_BPBR { get; set; }
    }
}
