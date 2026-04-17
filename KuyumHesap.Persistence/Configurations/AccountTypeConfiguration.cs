using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            var data = new AccountType[]
            {
                new AccountType
                {
                    Id = 1,
                    AccountTypeName = "SERMAYELER",
                    BalanceOrder = 100,
                    IsSubBalanceCalculated = true,
                    IsActive = true,
                    CreatedDate = new DateTime(2026,04,01),
                    CreatedByUserId = 1,
                    IsDeleted = false,
                },
                new AccountType
                {
                    Id = 2,
                    AccountTypeName = "MÜŞTERİLER",
                    BalanceOrder = 1,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                new AccountType
                {
                    Id = 3,
                    AccountTypeName = "TOPTANCILAR",
                    BalanceOrder = 2,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                  new AccountType
                {
                    Id = 4,
                    AccountTypeName = "ATÖLYELER",
                    BalanceOrder = 3,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                    new AccountType
                {
                    Id = 5,
                    AccountTypeName = "BANKALAR",
                    BalanceOrder = 4,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                      new AccountType
                {
                    Id = 6,
                    AccountTypeName = "POSLAR",
                    BalanceOrder = 5,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                        new AccountType
                {
                    Id = 7,
                    AccountTypeName = "KASALAR",
                    BalanceOrder = 6,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                              new AccountType
                {
                    Id = 8,
                    AccountTypeName = "GİDER/GELİR",
                    BalanceOrder = 7,
                    IsSubBalanceCalculated = true,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                                    new AccountType
                {
                    Id = 9,
                    AccountTypeName = "İSKONTOLAR",
                    BalanceOrder = 8,
                    IsSubBalanceCalculated = true,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                                          new AccountType
                {
                    Id = 10,
                    AccountTypeName = "KAR/ZARAR",
                    BalanceOrder = 9,
                    IsSubBalanceCalculated = true,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },      new AccountType
                {
                    Id = 11,
                    AccountTypeName = "DEMİRBAŞLAR",
                    BalanceOrder = 10,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },      new AccountType
                {
                    Id = 12,
                    AccountTypeName = "ÖZELHESAPLAR",
                    BalanceOrder = 11,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },      new AccountType
                {
                    Id = 13,
                    AccountTypeName = "PERSONEL",
                    BalanceOrder = 12,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                              CreatedDate=new DateTime(2026,04,01)
                },
                                           new AccountType
                {
                    Id = 14,
                    AccountTypeName = "STOKLAR",
                    BalanceOrder = 13,
                    IsSubBalanceCalculated = false,
                    IsActive = true,
                    CreatedDate=new DateTime(2026,04,01)
                },


            };

            builder.HasData(data);
        }
    }
}
