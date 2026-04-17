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
        }
    }
}
