using KuyumHesap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuyumHesap.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            var data = new Currency[]
            {
                new Currency{Id = 1, CurrencyCode = "HAS", CurrencyName = "ALTIN 1000",
                    Symbol="HAS", Country="GLOBAL" , IsActive = true, IsBaseCurrency = true,IsNationalCurrency = false,
                    MetaCode = "ALTIN",BuyRate=Convert.ToDecimal(0.995000),SellRate = Convert.ToDecimal(1.005000),CreatedByUserId=1},

                  new Currency{Id = 2, CurrencyCode = "USD", CurrencyName = "AMERİKAN DOLARI",
                    Symbol="$", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "USDTRY",BuyRate=Convert.ToDecimal(0.990000),SellRate = Convert.ToDecimal(1.010000),CreatedByUserId=1},

                      new Currency{Id = 3, CurrencyCode = "TRY", CurrencyName = "TÜRK LİRASI",
                    Symbol="₺", Country="TÜRKİYE" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = true,
                    MetaCode = "",BuyRate=Convert.ToDecimal(1.000000),SellRate = Convert.ToDecimal(1.000000),CreatedByUserId=1},

                          new Currency{Id = 4, CurrencyCode = "EUR", CurrencyName = "AVRUPA PARA BİRİMİ",
                    Symbol="€", Country="AVRUPA BİRLİĞİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "EURTRY",BuyRate=Convert.ToDecimal( 0.990000),SellRate = Convert.ToDecimal(1.010000),CreatedByUserId=1},

                              new Currency{Id = 5, CurrencyCode = "CHF", CurrencyName = "İSVİÇRE FRANGI",
                    Symbol="CHF", Country="İSVİÇRE" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "CHFTRY",BuyRate=Convert.ToDecimal(0.990000),SellRate = Convert.ToDecimal(1.010000),CreatedByUserId=1},

                                  new Currency{Id = 6, CurrencyCode = "SAR", CurrencyName = "SUUDİ ARABİSTAN RİYALİ",
                    Symbol="SAR", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "SARTRY",BuyRate=Convert.ToDecimal(1.000000),SellRate = Convert.ToDecimal(1.000000),CreatedByUserId=1},

                                      new Currency{Id = 7, CurrencyCode = "GHS", CurrencyName = "GÜMÜŞ HASI",
                    Symbol="GHS", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "GUMUSTRY",BuyRate=Convert.ToDecimal(0.990000),SellRate = Convert.ToDecimal(1.010000),CreatedByUserId=1},

            };
            builder.HasData(data);

        }
    }
}
