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
                    MetaCode = "ALTIN",CreatedByUserId=1,          CreatedDate=new DateTime(2026,04,01)},

                  new Currency{Id = 2, CurrencyCode = "USD", CurrencyName = "AMERİKAN DOLARI",
                    Symbol="$", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "USDTRY" ,CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

                      new Currency{Id = 3, CurrencyCode = "TRY", CurrencyName = "TÜRK LİRASI",
                    Symbol="₺", Country="TÜRKİYE" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = true,
                    MetaCode = "",  CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

                          new Currency{Id = 4, CurrencyCode = "EUR", CurrencyName = "AVRUPA PARA BİRİMİ",
                    Symbol="€", Country="AVRUPA BİRLİĞİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "EURTRY",    CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

                              new Currency{Id = 5, CurrencyCode = "CHF", CurrencyName = "İSVİÇRE FRANGI",
                    Symbol="CHF", Country="İSVİÇRE" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "CHFTRY", CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

                                  new Currency{Id = 6, CurrencyCode = "SAR", CurrencyName = "SUUDİ ARABİSTAN RİYALİ",
                    Symbol="SAR", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "SARTRY", CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

                                      new Currency{Id = 7, CurrencyCode = "GHS", CurrencyName = "GÜMÜŞ HASI",
                    Symbol="GHS", Country="AMERİKA BİRLEŞİK DEVLETLERİ" , IsActive = true, IsBaseCurrency = false,IsNationalCurrency = false,
                    MetaCode = "GUMUSTRY" ,CreatedByUserId=1, CreatedDate = new DateTime(2026, 04, 01)},

            };
            builder.HasData(data);

        }
    }
}
