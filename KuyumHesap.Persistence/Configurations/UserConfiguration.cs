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
                RoleId = 1,
                FirstName = "Mahmut",
                LastName = "Kavalcı",
                Email = "mahmut.kavalci@gmail.com",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "+905353348460",
                Active = true,
                BagliHesapID = null
            },
                 new Users {
                Id = 2,
                RoleId = 1,
                FirstName = "Samet",
                LastName = "Bağlan",
                Email = "samt51.m@icloud.com",
                Password = PasswordHashExtension.HashPassword("123456"),
                Phone = "+905363956979",
                Active = true,
                BagliHesapID = null
            }
        };
            builder.HasData(data);

        }
    }
}
