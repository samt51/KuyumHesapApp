using KuyumHesap.Application.Common.Abstractions.Aut.Jwt;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.Repositories;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Persistence.Common.Concrete.Auth;
using KuyumHesap.Persistence.Common.Concrete.Mapping;
using KuyumHesap.Persistence.Common.Concrete.Repositories;
using KuyumHesap.Persistence.Common.Concrete.SqlFunctions;
using KuyumHesap.Persistence.Common.Concrete.SqlFunctions.AccountBalanceFunc;
using KuyumHesap.Persistence.Common.Concrete.SqlViews;
using KuyumHesap.Persistence.Common.Concrete.UnitOfWorks;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KuyumHesap.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(connectionString));


            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddSingleton<IMapper, Mapper>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IAccountBalanceQuery, AccountBalanceQuerySqlFunc>();

            services.AddScoped<ITotalHasBalanceQuery, TotalHasBalanceQuery>();

            services.AddScoped<IAccountStatementQuery, AccountStatementQuery>();


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });

        }
    }
}
