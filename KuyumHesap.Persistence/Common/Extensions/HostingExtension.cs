using KuyumHesap.Persistence.Common.Context;
using KuyumHesap.Persistence.Common.SqlViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KuyumHesap.Persistence.Common.Extensions
{
    public static class HostingExtensions
    {
        public static async Task MigrateDevAndSeedAsync<TContext>(
            this IHost host,
            Func<TContext, IServiceProvider, Task>? devSeed = null)
            where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;
            var env = sp.GetRequiredService<IHostEnvironment>();
            if (!env.IsDevelopment()) return;

            var db = sp.GetRequiredService<TContext>();
            var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger("EF.Migration");

            var migrations = db.Database.GetMigrations();
            if (migrations.Any())
            {
                await db.Database.MigrateAsync();
                logger.LogInformation("Development database migrated.");
            }
            else
            {
                var created = await db.Database.EnsureCreatedAsync();
                logger.LogInformation(
                    created
                        ? "Development database created with the current model."
                        : "Development database already exists.");
            }

            // Persistence katmanında view'leri garantiye al
            if (db is AppDbContext appDb)
            {
                await ViewManager.EnsureViewsAsync(appDb);
            }

            if (devSeed is not null) await devSeed(db, sp);
            logger.LogInformation("Development migrate & seed completed.");
        }

        public static class DevSeeder
        {
            public static async Task SeedAsync(AppDbContext db, CancellationToken ct = default)
            {
                // existing seeder code...
            }
        }
    }
}
