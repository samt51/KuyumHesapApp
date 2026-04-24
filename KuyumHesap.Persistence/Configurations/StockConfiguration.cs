using System;
using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            // MillRate için 3 ondalık basamak ayarı
            builder.Property(s => s.MillRate)
                   .HasPrecision(18, 3);

            builder.HasOne(s => s.StockType)
                   .WithMany(st => st.Stocks)
                   .HasForeignKey(s => s.StockTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.StockGroup)
                   .WithMany(sg => sg.Stocks)
                   .HasForeignKey(s => s.StockGroupId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Stocks Seed Data
            builder.HasData(
                new Stock { Id = 1, StockName = "14 K", StockTypeId = 1, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.585m, IsActive = true, CreatedDate = DateTime.Parse("2026-04-18T14:14:26.8024130"), IsDeleted = false, CreatedByUserId = 1 },
                new Stock { Id = 2, StockName = "18 K", StockTypeId = 1, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.750m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-08T22:13:23.6866667"), ModifyDate = DateTime.Parse("2025-09-08T22:49:43.5133333"), IsDeleted = false, CreatedByUserId = 6, UpdatedByUserId = 6 },
                new Stock { Id = 3, StockName = "8 K", StockTypeId = 1, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.333m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-08T22:13:39.5366667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 4, StockName = "21 K", StockTypeId = 1, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.875m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-08T22:50:06.4133333"), ModifyDate = DateTime.Parse("2025-09-08T22:50:37.8600000"), IsDeleted = false, CreatedByUserId = 6, UpdatedByUserId = 6 },
                new Stock { Id = 5, StockName = "22 K", StockTypeId = 1, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.916m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-08T22:50:25.5633333"), ModifyDate = DateTime.Parse("2025-09-08T22:50:42.9100000"), IsDeleted = false, CreatedByUserId = 6, UpdatedByUserId = 6 },
                new Stock { Id = 6, StockName = "14 HURDASI", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.575m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:18:31.7700000"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 7, StockName = "18 HURDASI", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.730m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:19:01.9800000"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 8, StockName = "21 HURDASI", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.850m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:19:32.5566667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 9, StockName = "22 HURDASI", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.912m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:19:49.1666667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 10, StockName = "8 HURDASI", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.320m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:20:13.1433333"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 11, StockName = "995 ÇEKİLİ HURDA", StockTypeId = 3, StockGroupId = 3, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.995m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T02:20:58.4266667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 12, StockName = "925 GÜMÜŞ HURDA", StockTypeId = 4, StockGroupId = 3, UnitName = "Gram", StockUnitId = 8, LaborUnitId = 8, MillRate = 0.900m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-09T18:12:11.5700000"), ModifyDate = DateTime.Parse("2025-09-12T17:16:24.9700000"), IsDeleted = false, CreatedByUserId = 6, UpdatedByUserId = 6 },
                new Stock { Id = 13, StockName = "ZİYNET ÇEYREK", StockTypeId = 8, StockGroupId = 2, UnitName = "Adet", StockUnitId = 1, LaborUnitId = 1, MillRate = 1.605m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-12T17:16:11.0066667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 14, StockName = "ATA ÇEYREK", StockTypeId = 8, StockGroupId = 2, UnitName = "Adet", StockUnitId = 1, LaborUnitId = 1, MillRate = 1.650m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-12T17:16:50.5600000"), ModifyDate = DateTime.Parse("2025-09-20T11:51:33.5233333"), IsDeleted = false, CreatedByUserId = 6, UpdatedByUserId = 6 },
                new Stock { Id = 15, StockName = "22 GRAMALTIN", StockTypeId = 8, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.916m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-12T17:17:12.6466667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 16, StockName = "24 GRAMALTIN", StockTypeId = 8, StockGroupId = 2, UnitName = "Gram", StockUnitId = 1, LaborUnitId = 1, MillRate = 0.995m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-12T17:17:31.6366667"), IsDeleted = false, CreatedByUserId = 6 },
                new Stock { Id = 17, StockName = "PIRLANTA", StockTypeId = 5, StockGroupId = 1, UnitName = "Carat", StockUnitId = 2, LaborUnitId = 2, MillRate = 1.000m, IsActive = true, CreatedDate = DateTime.Parse("2025-09-20T12:39:17.7866667"), IsDeleted = false, CreatedByUserId = 6 }
            );
        }
    }
}
