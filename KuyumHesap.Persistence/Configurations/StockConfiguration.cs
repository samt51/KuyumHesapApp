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
        }
    }
}