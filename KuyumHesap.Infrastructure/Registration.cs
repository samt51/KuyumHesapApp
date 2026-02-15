using KuyumHesap.Application.Common.Abstractions.Aut;
using KuyumHesap.Infrastructure.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KuyumHesap.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddScoped<IKurGuncellemeService, KurGuncellemeService>();

            services.AddHttpClient();



            return services;

        }
    }
}
