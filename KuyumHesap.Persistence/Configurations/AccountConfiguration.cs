using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.AccountType)
                   .WithMany(at => at.Accounts)
                   .HasForeignKey(a => a.AccountTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
