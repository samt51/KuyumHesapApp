using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            var data = new Roles[]
            {
                new Roles { Id = 1, Name = "Admin", Code = "ADMIN", Type = "System",          CreatedDate=new DateTime(2026,04,01) },
                new Roles { Id = 2, Name = "User", Code = "USER", Type = "System" , CreatedDate = new DateTime(2026, 04, 01)},
                new Roles { Id = 3, Name = "SystemAdmin", Code = "SYSTEMADMIN", Type = "System" , CreatedDate = new DateTime(2026, 04, 01)}
            };
            builder.HasData(data);
        }
    }
}
