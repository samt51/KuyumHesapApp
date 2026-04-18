using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            var data = new Users[]
            {
                new Users {
                Id = 1,
                RoleId = 3,
                FirstName = "Mahmut",
                LastName = "Kavalcı",
                UserName = "MAHMUT",
                CompanyCode ="KUYUM-001",
                BranchCode="0001",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "+905353348460",
                Active = true,
                BagliHesapID = null,
                          CreatedDate=new DateTime(2026,04,01)
            },
                 new Users {
                Id = 2,
                RoleId = 3,
                FirstName = "Samet",
                LastName = "Bağlan",
                UserName = "SAMET",
                CompanyCode ="KUYUM-001",
                BranchCode="0001",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "+905363956979",
                Active = true,
                BagliHesapID = null,
                          CreatedDate=new DateTime(2026,04,01)
            }
        };
            builder.HasData(data);

        }
    }
}
