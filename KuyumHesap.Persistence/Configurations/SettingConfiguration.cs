using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Key).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Key).IsUnique().HasFilter("[IsDeleted] = 0");

            var data = new Setting[]
            {
                new Setting { Id = 1, Key = "CashAccountTypeId",         Description = "Nakit tahsilat/ödeme işlemlerinde kullanılacak kasa hesabının AccountType ID'si", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 2, Key = "PosAccountTypeId",          Description = "POS cihazı üzerinden yapılan tahsilat/ödeme hesabının AccountType ID'si", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 3, Key = "BankAccountTypeId",         Description = "Banka havalesi/EFT işlemlerinde kullanılacak hesabın AccountType ID'si", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 4, Key = "SalesCurrencyId",           Description = "Satış işlemlerinde varsayılan olarak seçilecek para biriminin Currency ID'si", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 5, Key = "CashierAccountTypeId",      Description = "Satış ekranında tezgahtar seçiminde listelenen hesapların AccountType ID'si", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 6, Key = "CustomerAccountTypeId",     Description = "Satış ekranında müşteri listesinde gösterilecek hesapların AccountType ID'si", CreatedDate =new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 7, Key = "DefaultCustomerAccountId",  Description = "Satış ekranı açıldığında varsayılan olarak seçili gelecek müşteri Account ID'si", CreatedDate =new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 8, Key = "DefaultCashAccountId",  Description = "Nakit tahsilat/ödeme işlemlerinde varsayılan kasa hesabı", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 },
                new Setting { Id = 9, Key = "DefaultDiscountAccountId",  Description = "İskonto işlemlerinde borçlandırılacak hesap", CreatedDate = new DateTime(2026, 04, 01), CreatedByUserId = 1 }
            };

            builder.HasData(data);
        }
    }
}
