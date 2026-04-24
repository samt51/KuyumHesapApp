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
                UserName = "SYSTEMADMIN",
                CompanyCode ="KUYUM",
                BranchCode="0001",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "+905353348460",
                Active = true,
                BagliHesapID = null,
                          CreatedDate=new DateTime(2026,04,01)
            },
                 new Users {
                Id = 2,
                RoleId = 1,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "ADMIN",
                CompanyCode ="KUYUM",
                BranchCode="0001",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "",
                Active = true,
                BagliHesapID = null,
                          CreatedDate=new DateTime(2026,04,01)
            },
                       new Users {
                Id = 3,
                RoleId = 2,
                FirstName = "User",
                LastName = "User",
                UserName = "USER",
                CompanyCode ="KUYUM",
                BranchCode="0001",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "",
                Active = true,
                BagliHesapID = null,
                          CreatedDate=new DateTime(2026,04,01)
            }
        };
            builder.HasData(data);

        }
    }
}
