using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KuyumHesap.Persistence.Common.Extensions
{
    public static class HostingExtensions
    {
        public static async Task MigrateDevAndSeedAsync<TContext>(
            this IHost host,
            Func<TContext, IServiceProvider, Task>? devSeed = null)
            where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;
            var env = sp.GetRequiredService<IHostEnvironment>();
            if (!env.IsDevelopment()) return;

            var db = sp.GetRequiredService<TContext>();
            var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger("EF.Migration");

            await db.Database.MigrateAsync();
            if (devSeed is not null) await devSeed(db, sp);
            logger.LogInformation("Development migrate & seed completed.");
        }

        public static class DevSeeder
        {
            public static async Task SeedAsync(AppDbContext db, CancellationToken ct = default)
            {
              //  if (!await db.AccountTypes.AnyAsync(ct))
              //  {
              //      await db.AccountTypes.AddRangeAsync(
              //       new AccountType
              //       {
              //           Id = 1,
              //           AccountTypeName = "SERMAYELER",
              //           BalanceOrder = 100,
              //           IsSubBalanceCalculated = true,
              //           IsActive = true,
              //           CreatedDate = DateTime.Now,
              //           CreatedByUserId = 1,
              //           IsDeleted = false,
              //       },
              //         new AccountType
              //         {
              //             Id = 2,
              //             AccountTypeName = "MÜŞTERİLER",
              //             BalanceOrder = 1,
              //             IsSubBalanceCalculated = false,
              //             IsActive = true
              //         },
              //new AccountType
              //{
              //    Id = 3,
              //    AccountTypeName = "TOPTANCILAR",
              //    BalanceOrder = 2,
              //    IsSubBalanceCalculated = false,
              //    IsActive = true
              //},
              //  new AccountType
              //  {
              //      Id = 4,
              //      AccountTypeName = "ATÖLYELER",
              //      BalanceOrder = 3,
              //      IsSubBalanceCalculated = false,
              //      IsActive = true
              //  },
              //    new AccountType
              //    {
              //        Id = 5,
              //        AccountTypeName = "BANKALAR",
              //        BalanceOrder = 4,
              //        IsSubBalanceCalculated = false,
              //        IsActive = true
              //    },
              //      new AccountType
              //      {
              //          Id = 6,
              //          AccountTypeName = "POSLAR",
              //          BalanceOrder = 5,
              //          IsSubBalanceCalculated = false,
              //          IsActive = true
              //      },
              //        new AccountType
              //        {
              //            Id = 7,
              //            AccountTypeName = "KASALAR",
              //            BalanceOrder = 6,
              //            IsSubBalanceCalculated = false,
              //            IsActive = true
              //        },
              //              new AccountType
              //              {
              //                  Id = 8,
              //                  AccountTypeName = "GİDER/GELİR",
              //                  BalanceOrder = 7,
              //                  IsSubBalanceCalculated = true,
              //                  IsActive = true
              //              },
              //                    new AccountType
              //                    {
              //                        Id = 9,
              //                        AccountTypeName = "İSKONTOLAR",
              //                        BalanceOrder = 8,
              //                        IsSubBalanceCalculated = true,
              //                        IsActive = true
              //                    },
              //                          new AccountType
              //                          {
              //                              Id = 10,
              //                              AccountTypeName = "KAR/ZARAR",
              //                              BalanceOrder = 9,
              //                              IsSubBalanceCalculated = true,
              //                              IsActive = true
              //                          }, new AccountType
              //                          {
              //                              Id = 11,
              //                              AccountTypeName = "DEMİRBAŞLAR",
              //                              BalanceOrder = 10,
              //                              IsSubBalanceCalculated = false,
              //                              IsActive = true
              //                          }, new AccountType
              //                          {
              //                              Id = 12,
              //                              AccountTypeName = "ÖZELHESAPLAR",
              //                              BalanceOrder = 11,
              //                              IsSubBalanceCalculated = false,
              //                              IsActive = true
              //                          }, new AccountType
              //                          {
              //                              Id = 13,
              //                              AccountTypeName = "PERSONEL",
              //                              BalanceOrder = 12,
              //                              IsSubBalanceCalculated = false,
              //                              IsActive = true
              //                          },
              //                           new AccountType
              //                           {
              //                               Id = 14,
              //                               AccountTypeName = "STOKLAR",
              //                               BalanceOrder = 13,
              //                               IsSubBalanceCalculated = false,
              //                               IsActive = true
              //                           });

              //      await db.SaveChangesAsync(ct);

              //  }

              //  if (!await db.MovementTypes.AnyAsync(ct))
              //  {
              //      await db.MovementTypes.AddRangeAsync(new MovementType
              //      {
              //          Id = 1,
              //          TransactionCode = "NG",
              //          TransactionName = "NAKİT GİRİŞ",
              //          GC = 'G',
              //          SC = 'C',
              //          IsActive = true,
              //          Description = "NAKİT GİRİŞ İŞLEMLERİ İÇİN KULLANILIR",
              //          AutoGeneratedTransactionTypeId = 2,
              //          CreatedByUserId = 1
              //      },
              //  new MovementType
              //  {
              //      Id = 2,
              //      TransactionCode = "NC",
              //      TransactionName = "NAKİT ÇIKIŞ",
              //      GC = 'C',
              //      SC = 'G',
              //      IsActive = true,
              //      Description = "NAKİT ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 1,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 3,
              //      TransactionCode = "UG",
              //      TransactionName = "ÜRÜN GİRİŞ",
              //      GC = 'G',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "ÜRÜN GİRİŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 4,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 4,
              //      TransactionCode = "UC",
              //      TransactionName = "ÜRÜN ÇIKIŞ",
              //      GC = 'C',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "ÜRÜN ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 3,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 5,
              //      TransactionCode = "ALC",
              //      TransactionName = "ISKONTO ALACAKLANDIR",
              //      GC = 'G',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "HESABIN ALACAĞINA İSKONTO YAZMAK İÇİN",
              //      AutoGeneratedTransactionTypeId = 6,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 6,
              //      TransactionCode = "BRC",
              //      TransactionName = "ISKONTO BORCLANDIR",
              //      GC = 'C',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "HESABIN BORCUNA İSKONTO YAZMAK İÇİN",
              //      AutoGeneratedTransactionTypeId = 5,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 7,
              //      TransactionCode = "VRG",
              //      TransactionName = "VİRMAN GİRİŞ",
              //      GC = 'G',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "VİRMAN(HAVALE) GİRİŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 8,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 8,
              //      TransactionCode = "VRC",
              //      TransactionName = "VİRMAN ÇIKIŞ",
              //      GC = 'C',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "VİRMAN(HAVALE) ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 7,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 9,
              //      TransactionCode = "CVG",
              //      TransactionName = "ÇEVİRME GİRİŞ",
              //      GC = 'G',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "ÇEVİRME GİRİŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 10,
              //      CreatedByUserId = 1
              //  },
              //  new MovementType
              //  {
              //      Id = 10,
              //      TransactionCode = "CVC",
              //      TransactionName = "ÇEVİRME ÇIKIŞ",
              //      GC = 'C',
              //      SC = 'C',
              //      IsActive = true,
              //      Description = "ÇEVİRME ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR",
              //      AutoGeneratedTransactionTypeId = 9,
              //      CreatedByUserId = 1
              //  });
              //      await db.SaveChangesAsync(ct);
              //  }

              //  if (!await db.ProductTypes.AnyAsync(ct))
              //  {
              //      await db.ProductTypes.AddRangeAsync(new ProductType { Id = 1, ProductTypeName = "YÜZÜK", CreatedByUserId = 1 },
              //  new ProductType { Id = 2, ProductTypeName = "KÜPE", CreatedByUserId = 1 },
              //  new ProductType { Id = 3, ProductTypeName = "ALYANS", CreatedByUserId = 1 },
              //  new ProductType { Id = 4, ProductTypeName = "BİLEKLİK", CreatedByUserId = 1 },
              //  new ProductType { Id = 5, ProductTypeName = "KELEPÇE", CreatedByUserId = 1 });

              //      await db.SaveChangesAsync(ct);
              //  }

              //  if (!await db.StockGroups.AnyAsync(ct))
              //  {
              //      await db.StockGroups.AddRangeAsync(new StockGroup { Id = 1, StockGroupName = "MAMUL GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 },
              //  new StockGroup { Id = 2, StockGroupName = "MADEN GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 },
              //  new StockGroup { Id = 3, StockGroupName = "HURDA GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 },
              //  new StockGroup { Id = 4, StockGroupName = "PIRLANTA TAŞ GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 },
              //  new StockGroup { Id = 5, StockGroupName = "ELMAS TAŞ GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 },
              //  new StockGroup { Id = 6, StockGroupName = "RENKLİ TAŞ GRUBU", CreatedDate = DateTime.Now, CreatedByUserId = 1 });

              //      await db.SaveChangesAsync(ct);
              //  }

              //  if (!await db.Roles.AnyAsync(ct))
              //  {
              //      await db.Roles.AddRangeAsync(new Roles { Id = 1, Name = "Admin", Code = "ADMIN", Type = "System" },
              //  new Roles { Id = 2, Name = "User", Code = "USER", Type = "System" });

              //      await db.SaveChangesAsync(ct);
              //  }

              //  if (!await db.Users.AnyAsync(ct))
              //  {
              //      await db.Users.AddRangeAsync(new Users
              //      {
              //          Id = 1,
              //          RoleId = 1,
              //          FirstName = "Mahmut",
              //          LastName = "Kavalcı",
              //          Email = "mahmut.kavalci@gmail.com",
              //          Password = PasswordHashExtension.HashPassword("123456"),
              //          Phone = "+905353348460",
              //          Active = true,
              //          BagliHesapID = null
              //      },
              //   new Users
              //   {
              //       Id = 2,
              //       RoleId = 1,
              //       FirstName = "Samet",
              //       LastName = "Bağlan",
              //       Email = "samt51.m@icloud.com",
              //       Password = PasswordHashExtension.HashPassword("123456"),
              //       Phone = "+905363956979",
              //       Active = true,
              //       BagliHesapID = null
              //   });

              //      await db.SaveChangesAsync(ct);
              //  }
            }
        }
    }
}
