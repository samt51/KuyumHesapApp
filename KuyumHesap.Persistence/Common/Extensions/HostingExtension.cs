using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Domain.Entities;
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

            await db.Database.MigrateAsync();

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