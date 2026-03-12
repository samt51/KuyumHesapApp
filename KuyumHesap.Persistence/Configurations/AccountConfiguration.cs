using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            var data = new Account[]
            {
                new Account
                {
                    Id = 1,
                    AccountName = "KASA",
                    AccountTypeId = 7,
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = 1,
                    IsDeleted = false,
                           CustomerType="Sistem"
                },
                new Account
                {
                    Id = 2,
                    AccountName = "PEŞİN MÜŞTERİ",
                    AccountTypeId = 2,
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = 1,
                    IsDeleted = false,
                    CustomerType="Sistem"
                },
                new Account
                {
                    Id = 3,
                    AccountName = "İSKONTO SATIŞTAN",
                    AccountTypeId = 9,
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = 1,
                    IsDeleted = false,
                           CustomerType="Sistem"
                },
            };

            builder.HasData(data);
        }
    }
}
