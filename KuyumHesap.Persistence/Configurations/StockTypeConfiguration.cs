using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class StockTypeConfiguration : IEntityTypeConfiguration<StockType>
    {
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            var data = new StockType[]
            {
                new StockType{Id = 1,StockTypeName="ALTIN" ,StockGroupId  = 2,CurrencyId=1,IsActive=true,CreatedByUserId = 1},

                    new StockType{Id = 2,StockTypeName="GÜMÜŞ" ,StockGroupId  = 2,CurrencyId=8,IsActive=true,CreatedByUserId = 1},

                        new StockType{Id = 3,StockTypeName="HURDA ALTIN" ,StockGroupId  = 3,CurrencyId=1,IsActive=true,CreatedByUserId = 1},

                            new StockType{Id = 4,StockTypeName="HURDA GÜMÜŞ" ,StockGroupId  = 3,CurrencyId=7,IsActive=true,CreatedByUserId = 1},

                                new StockType{Id = 5,StockTypeName="PIRLANTA" ,StockGroupId  = 1,CurrencyId=2,IsActive=true,CreatedByUserId = 1},

                                    new StockType{Id = 6,StockTypeName="SAAT" ,StockGroupId  = 1,CurrencyId=3,IsActive=true,CreatedByUserId = 1},

                                    new StockType{Id = 7,StockTypeName="ELMAS" ,StockGroupId  = 1,CurrencyId=2,IsActive=true,CreatedByUserId = 1},

                                    new StockType{Id = 8,StockTypeName="SARRAFİYE" ,StockGroupId  = 2,CurrencyId=1,IsActive=true,CreatedByUserId = 1},

             };

            builder.HasData(data);
        }
    }
}
