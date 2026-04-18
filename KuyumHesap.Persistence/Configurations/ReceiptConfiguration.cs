using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasOne(r => r.Account)
                   .WithMany(a => a.Receipts)
                   .HasForeignKey(r => r.AccountId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
