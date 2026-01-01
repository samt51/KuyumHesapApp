using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class StockGroupConfiguration : IEntityTypeConfiguration<StockGroup>
    {
        public void Configure(EntityTypeBuilder<StockGroup> builder)
        {
            var data = new StockGroup[]
            {
                new StockGroup { Id = 1, StockGroupName = "MAMUL GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 },
                new StockGroup { Id = 2, StockGroupName = "MADEN GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 },
                new StockGroup { Id = 3, StockGroupName = "HURDA GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 },
                new StockGroup { Id = 4, StockGroupName = "PIRLANTA TAŞ GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 },
                new StockGroup { Id = 5, StockGroupName = "ELMAS TAŞ GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 },
                new StockGroup { Id = 6, StockGroupName = "RENKLİ TAŞ GRUBU", CreatedDate = DateTime.Now,CreatedByUserId = 1 }
            };
            builder.HasData(data);
        }
    }
}
