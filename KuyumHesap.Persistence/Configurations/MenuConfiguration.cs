using System;
using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            var data = new Menu[]
            {
                new Menu { Id = 1, ParentId = null, Name = "Ana Sayfa", Code = "DASHBOARD_VIEW", Url = "/Dashboard/IndexDashboard", IconUrl = "fas fa-home w-6 text-center text-xl text-gray-500", OrderNo = 1, RequeiredPermissionCode = "DASHBOARD_VIEW", CreatedDate = DateTime.Parse("2026-04-16T03:43:46.3383950"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 82, ParentId = null, Name = "Satış Ve Cari", Code = "SELLANDCARI_VIEW", Url = "/SellAndCari/Index", IconUrl = "fas fa-shopping-cart w-6 text-center text-xl text-gray-500", OrderNo = 2, RequeiredPermissionCode = "SELLANDCARI_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 83, ParentId = null, Name = "Cari Raporlar", Code = "REPORTS_ROOT", Url = "", IconUrl = "fas fa-chart-line w-6 text-center text-xl text-gray-500", OrderNo = 3, RequeiredPermissionCode = "REPORTS_ROOT", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 84, ParentId = null, Name = "Tanımlamalar", Code = "DEFINITIONS_ROOT", Url = "", IconUrl = "fas fa-sitemap w-6 text-center text-xl text-gray-500", OrderNo = 4, RequeiredPermissionCode = "DEFINITIONS_ROOT", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 85, ParentId = 83, Name = "Kasa Raporu", Code = "CASH_REPORT_VIEW", Url = "/Report/GetCashReport", IconUrl = "fas fa-wallet", OrderNo = 1, RequeiredPermissionCode = "CASH_REPORT_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 86, ParentId = 83, Name = "Nakit Giriş Çıkış Raporu", Code = "CASH_IN_OUT_REPORT_VIEW", Url = "/Report/GetCashReport", IconUrl = "fas fa-exchange-alt", OrderNo = 2, RequeiredPermissionCode = "CASH_IN_OUT_REPORT_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 87, ParentId = 84, Name = "Hesap Tanımlama", Code = "ACCOUNT_VIEW", Url = "/Account/Index", IconUrl = "fas fa-tags", OrderNo = 1, RequeiredPermissionCode = "ACCOUNT_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 88, ParentId = 84, Name = "Hesap Tipleri Tanımlama", Code = "ACCOUNT_TYPE_VIEW", Url = "/AccountType/Index", IconUrl = "fas fa-tags", OrderNo = 2, RequeiredPermissionCode = "ACCOUNT_TYPE_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 89, ParentId = 84, Name = "Döviz Tanımlama", Code = "CURRENCY_VIEW", Url = "/Currency/Index", IconUrl = "fas fa-coins", OrderNo = 3, RequeiredPermissionCode = "CURRENCY_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 90, ParentId = 84, Name = "Stok Grubu Tanımlama", Code = "STOCK_GROUP_VIEW", Url = "/StockGroup/Index", IconUrl = "fas fa-layer-group", OrderNo = 4, RequeiredPermissionCode = "STOCK_GROUP_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 91, ParentId = 84, Name = "Stok Tipleri Tanımlama", Code = "STOCK_TYPE_VIEW", Url = "/StockType/Index", IconUrl = "fas fa-cubes", OrderNo = 5, RequeiredPermissionCode = "STOCK_TYPE_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 92, ParentId = 84, Name = "Stok Tanımlama", Code = "STOCK_VIEW", Url = "/Stock/Index", IconUrl = "fas fa-box", OrderNo = 6, RequeiredPermissionCode = "STOCK_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 93, ParentId = 84, Name = "Ürün Tipi Tanımlama", Code = "PRODUCT_TYPE_VIEW", Url = "/ProductType/Index", IconUrl = "fas fa-gem", OrderNo = 7, RequeiredPermissionCode = "PRODUCT_TYPE_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 94, ParentId = 84, Name = "Kullanıcı Tanımlama", Code = "USER_VIEW", Url = "/User/Index", IconUrl = "fas fa-users-cog", OrderNo = 8, RequeiredPermissionCode = "USER_VIEW", CreatedDate = DateTime.Parse("2026-04-17T02:02:16.0200000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 98, ParentId = null, Name = "Ayarlar", Code = "SETTINGS_ROOT", Url = "", IconUrl = "fas fa-cogs w-6 text-center text-xl text-gray-500", OrderNo = 5, RequeiredPermissionCode = "SETTINGS_ROOT", CreatedDate = DateTime.Parse("2026-04-18T07:20:11.0000000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 99, ParentId = 98, Name = "Genel Ayarlar", Code = "SETTINGS_GENEL_VIEW", Url = "/Settings/Index", IconUrl = "fas fa-cog", OrderNo = 1, RequeiredPermissionCode = "SETTINGS_GENEL_VIEW", CreatedDate = DateTime.Parse("2026-04-18T07:20:11.0000000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 100, ParentId = 98, Name = "Barkod Ayarları", Code = "SETTINGS_BARKOD_VIEW", Url = "/BarcodeSettings/Index", IconUrl = "fas fa-barcode", OrderNo = 2, RequeiredPermissionCode = "SETTINGS_BARKOD_VIEW", CreatedDate = DateTime.Parse("2026-04-18T07:20:11.0033333"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 101, ParentId = 98, Name = "Menü Ayarları ve İzinler", Code = "SETTINGS_MENU", Url = "/MenuSettings/Index", IconUrl = "fas fa-list", OrderNo = 3, RequeiredPermissionCode = "SETTINGS_MENU", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2766667"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 102, ParentId = 98, Name = "Sayfa Aksiyonları", Code = "SETTINGS_PAGE_ACTION", Url = "/PageActionSettings/Index", IconUrl = "fas fa-toggle-on", OrderNo = 4, RequeiredPermissionCode = "SETTINGS_PAGE_ACTION", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2800000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true },
                new Menu { Id = 103, ParentId = 98, Name = "İzinler", Code = "SETTINGS_PERMISSIONS", Url = "/Permissions/Index", IconUrl = "fas fa-user-shield", OrderNo = 5, RequeiredPermissionCode = "SETTINGS_PERMISSIONS", CreatedDate = DateTime.Parse("2026-04-18T07:46:42.2800000"), IsDeleted = false, CreatedByUserId = 1, IsActive = true }
            };
            builder.HasData(data);
        }
    }
}
