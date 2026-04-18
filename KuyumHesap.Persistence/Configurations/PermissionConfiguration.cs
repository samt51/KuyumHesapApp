using System;
using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var data = new Permission[]
            {
                new Permission { Id = 4, Code = "DASHBOARD_VIEW", Name = "Ana Sayfa", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.0111055"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 5, Code = "SELLANDCARI_VIEW", Name = "Satış Ve Cari", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.0939078"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 6, Code = "REPORTS_ROOT", Name = "Cari Raporlar", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.1423436"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 7, Code = "DEFINITIONS_ROOT", Name = "Tanımlamalar", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.2064989"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 8, Code = "SATIS_CARI_NAKIT_GIRIS", Name = "Nakit Giriş", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.3540354"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 9, Code = "SATIS_CARI_CRM", Name = "CRM", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.4155333"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 10, Code = "SATIS_CARI_EKSTRE", Name = "Ekstre", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.4581016"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 11, Code = "SATIS_CARI_NAKIT_CIKIS", Name = "Nakit Çıkış", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.4988579"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 12, Code = "SATIS_CARI_URUN_GIRIS", Name = "Ürün Giriş", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.5449639"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 13, Code = "SATIS_CARI_LISTE", Name = "Cari Liste", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.6031762"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 14, Code = "SATIS_CARI_URUN_CIKIS", Name = "Ürün Çıkış", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.6537409"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 15, Code = "SATIS_CARI_ISKONTO", Name = "İskonto", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.7889634"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 16, Code = "SATIS_CARI_VIRMAN", Name = "Virman", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.8534540"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 17, Code = "SATIS_CARI_ACIK_HESAP", Name = "Açık Hesap", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.9110806"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 18, Code = "SATIS_CARI_CEVIRI", Name = "Çeviri", CreatedDate = DateTime.Parse("2026-04-17T04:15:41.9719923"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 19, Code = "SATIS_CARI_KALEM_EKLE", Name = "Kalem Ekle", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.0580734"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 20, Code = "SATIS_CARI_KALEM_SIL", Name = "Kalem Sil", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.1395336"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 21, Code = "SATIS_CARI_FIS_KAYDET", Name = "Fiş Kaydet", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.2394560"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 22, Code = "SATIS_CARI_YENI_ISLEM", Name = "Yeni İşlem", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.6580454"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 23, Code = "SATIS_CARI_FIS_SIL", Name = "Fiş Sil", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.8713977"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 24, Code = "SATIS_CARI_NAKIT_TAHSILAT", Name = "Nakit Tahsilat", CreatedDate = DateTime.Parse("2026-04-17T04:15:42.9547189"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 25, Code = "SATIS_CARI_NAKIT_ODEME", Name = "Nakit Ödeme", CreatedDate = DateTime.Parse("2026-04-17T04:15:43.0254522"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 26, Code = "SATIS_CARI_URUN_ALIS", Name = "Ürün Alış", CreatedDate = DateTime.Parse("2026-04-17T04:15:43.2225784"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 27, Code = "SATIS_CARI_URUN_SATIS", Name = "Ürün Satış", CreatedDate = DateTime.Parse("2026-04-17T04:15:43.2939680"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 28, Code = "ACCOUNT_VIEW", Name = "Hesap Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.0555203"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 29, Code = "CASH_REPORT_VIEW", Name = "Kasa Raporu", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.0943770"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 30, Code = "CASH_IN_OUT_REPORT_VIEW", Name = "Nakit Giriş Çıkış Raporu", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.1265704"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 31, Code = "ACCOUNT_TYPE_VIEW", Name = "Hesap Tipleri Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.1580956"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 32, Code = "CURRENCY_VIEW", Name = "Döviz Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.1887847"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 33, Code = "STOCK_GROUP_VIEW", Name = "Stok Grubu Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.2234144"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 34, Code = "STOCK_TYPE_VIEW", Name = "Stok Tipleri Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.2559451"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 35, Code = "STOCK_VIEW", Name = "Stok Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.2899268"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 36, Code = "PRODUCT_TYPE_VIEW", Name = "Ürün Tipi Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.3463792"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 37, Code = "USER_VIEW", Name = "Kullanıcı Tanımlama", CreatedDate = DateTime.Parse("2026-04-18T05:28:15.3773427"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 42, Code = "SETTINGS_ROOT", Name = "Ayarlar Menüsü", CreatedDate = DateTime.Parse("2026-04-18T07:17:39.3533333"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 43, Code = "SETTINGS_GENEL_VIEW", Name = "Genel Ayarlar", CreatedDate = DateTime.Parse("2026-04-18T07:17:39.3533333"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 44, Code = "SETTINGS_BARKOD_VIEW", Name = "Barkod Ayarları", CreatedDate = DateTime.Parse("2026-04-18T07:17:39.3533333"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 45, Code = "SETTINGS_MENU", Name = "Menü Ayarları Yönetimi", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2766667"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 46, Code = "SETTINGS_PAGE_ACTION", Name = "Sayfa Aksiyon Yönetimi", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2766667"), IsDeleted = false, CreatedByUserId = 1 },
                new Permission { Id = 47, Code = "SETTINGS_PERMISSIONS", Name = "İzin / Yetki Yönetimi", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2766667"), IsDeleted = false, CreatedByUserId = 1 }
            };
            builder.HasData(data);
        }
    }
}
