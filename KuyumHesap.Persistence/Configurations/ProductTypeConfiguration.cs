using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            var data = new ProductType[]
            {
                new ProductType { Id = 1, ProductTypeName = "YÜZÜK" ,CreatedByUserId =1},
                new ProductType { Id = 2, ProductTypeName = "KÜPE" ,CreatedByUserId=1},
                new ProductType { Id = 3, ProductTypeName = "ALYANS" ,CreatedByUserId = 1},
                new ProductType { Id = 4, ProductTypeName = "BİLEKLİK" ,CreatedByUserId = 1},
                new ProductType { Id = 5, ProductTypeName = "KELEPÇE" ,CreatedByUserId = 1}
            };
            builder.HasData(data);
        }
    }
}
