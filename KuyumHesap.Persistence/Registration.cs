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
using Microsoft.Extensions.Logging;
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
                opt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var authorization = context.Request.Headers.Authorization.FirstOrDefault();
                        var logger = context.HttpContext.RequestServices
                            .GetRequiredService<ILoggerFactory>()
                            .CreateLogger("JwtBearerDebug");

                        logger.LogInformation(
                            "JWT OnMessageReceived {Method} {Path}: HasAuthorization={HasAuthorization}, Authorization={Authorization}",
                            context.Request.Method,
                            context.Request.Path,
                            !string.IsNullOrWhiteSpace(authorization),
                            MaskAuthorizationHeader(authorization));

                        if (string.IsNullOrWhiteSpace(authorization))
                        {
                            return Task.CompletedTask;
                        }

                        if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                        {
                            context.Token = authorization["Bearer ".Length..].Trim();
                            logger.LogInformation("JWT token extracted from Bearer header. TokenLength={TokenLength}", context.Token.Length);
                            return Task.CompletedTask;
                        }

                        if (authorization.StartsWith("Bearer:", StringComparison.OrdinalIgnoreCase))
                        {
                            context.Token = authorization["Bearer:".Length..].Trim();
                            logger.LogInformation("JWT token extracted from Bearer: header. TokenLength={TokenLength}", context.Token.Length);
                            return Task.CompletedTask;
                        }

                        if (authorization.Count(x => x == '.') == 2)
                        {
                            context.Token = authorization.Trim();
                            logger.LogInformation("JWT token extracted from raw Authorization header. TokenLength={TokenLength}", context.Token.Length);
                        }

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        var logger = context.HttpContext.RequestServices
                            .GetRequiredService<ILoggerFactory>()
                            .CreateLogger("JwtBearerDebug");

                        logger.LogWarning(
                            context.Exception,
                            "JWT authentication failed {Method} {Path}: {ExceptionType} {Message}",
                            context.Request.Method,
                            context.Request.Path,
                            context.Exception.GetType().Name,
                            context.Exception.Message);

                        context.Response.Headers["X-Auth-Error"] = context.Exception.GetType().Name;
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        var logger = context.HttpContext.RequestServices
                            .GetRequiredService<ILoggerFactory>()
                            .CreateLogger("JwtBearerDebug");

                        logger.LogWarning(
                            "JWT challenge {Method} {Path}: Error={Error}, ErrorDescription={ErrorDescription}, HasAuthHeader={HasAuthHeader}",
                            context.Request.Method,
                            context.Request.Path,
                            context.Error,
                            context.ErrorDescription,
                            context.Request.Headers.ContainsKey("Authorization"));

                        if (!string.IsNullOrWhiteSpace(context.ErrorDescription))
                        {
                            context.Response.Headers["X-Auth-Error"] = context.ErrorDescription;
                        }

                        return Task.CompletedTask;
                    }
                };
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

        private static string MaskAuthorizationHeader(string? authorization)
        {
            if (string.IsNullOrWhiteSpace(authorization))
            {
                return "<empty>";
            }

            var value = authorization.Trim();
            var token = value.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                ? value["Bearer ".Length..].Trim()
                : value.StartsWith("Bearer:", StringComparison.OrdinalIgnoreCase)
                    ? value["Bearer:".Length..].Trim()
                    : value;

            if (token.Length <= 12)
            {
                return $"len={token.Length}";
            }

            var prefix = value.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase) ? "Bearer " : string.Empty;
            return $"{prefix}{token[..6]}...{token[^6..]} len={token.Length}";
        }
    }
}
