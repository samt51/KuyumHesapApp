using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Entities.VwModels;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.Context
{
    public class AppDbContext : DbContext
    {
        [DbFunction("fn_KurCevir", "dbo")]
        public static decimal KurCevir(
    DateTime tarih,
    string kaynakDoviz,
    string hedefDoviz,
    decimal miktar)
    => throw new NotSupportedException();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            b.
       Entity<EkstreSatirViewModel>()
       .HasNoKey()
       .ToView("vw_HesapEkstresi");



        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BarcodeHeader> BarcodeHeaders { get; set; }
        public DbSet<BarcodeDetail> BarcodeDetails { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<ExchangeRateTicker> ExchangeRateTickers { get; set; }
        public DbSet<Movements> Movements { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<EkstreSatirViewModel> ReceiptViews => Set<EkstreSatirViewModel>();

    }
}
