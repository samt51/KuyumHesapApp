using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class MovementConfiguration : IEntityTypeConfiguration<Movements>
    {
        public void Configure(EntityTypeBuilder<Movements> builder)
        {

            builder.Property(s => s.MillRate)
         .HasPrecision(18, 3);

            builder.Property(s => s.LaborCost)
    .HasPrecision(18, 3);

            builder.HasOne(m => m.Receipt)
                   .WithMany(r => r.Movements)
                   .HasForeignKey(m => m.ReceiptId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.TransactionType)
                   .WithMany(mt => mt.Movements)
                   .HasForeignKey(m => m.TransactionTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Account)
                   .WithMany(a => a.Movements)
                   .HasForeignKey(m => m.AccountId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Stock)
                   .WithMany(s => s.Movements)
                   .HasForeignKey(m => m.StockId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Currency>()
                   .WithMany()
                   .HasForeignKey(m => m.ForeignCurrencyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Currency>()
                   .WithMany()
                   .HasForeignKey(m => m.CounterCurrencyId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
