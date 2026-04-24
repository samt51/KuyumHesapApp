using Hangfire;
using KuyumHesap.Api.Common.Filters;
using KuyumHesap.Application;
using KuyumHesap.Application.Common.Abstractions.ServiceProvider;
using KuyumHesap.Application.Common.Middleware.ExceptionFilter;
using KuyumHesap.Infrastructure;
using KuyumHesap.Infrastructure.Services;
using KuyumHesap.Infrastructure.Services.Jobs;
using KuyumHesap.Persistence;
using KuyumHesap.Persistence.Common.Context;
using KuyumHesap.Persistence.Common.Extensions;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

EnsureConfiguredDatabasesExist(builder.Configuration);

var lc = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .Enrich.FromLogContext()
    .MinimumLevel.Information();

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    lc = lc.WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Log", AutoCreateSqlTable = true },
        columnOptions: new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn("UserId", System.Data.SqlDbType.VarChar)
            }
        });
}

Log.Logger = lc.CreateLogger();
builder.Host.UseSerilog(Log.Logger);
builder.Services.AddMemoryCache();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<DescriptionOperationFilter>();


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() }
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.CustomSchemaIds(t => t.FullName);

});

builder.Services.AddHttpClient("CureClient", c =>
{
    c.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddScoped<IExchangeRateProvider, PusulaExchangeRateProvider>();
builder.Services.AddScoped<IRefreshExchangeRatesUseCase, RefreshExchangeRatesUseCase>();
builder.Services.AddScoped<ExchangeRateHangfireJob>();

builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("HangfireConnection"));
});

builder.Services.AddHangfireServer(options =>
{
    options.ServerName = $"{Environment.MachineName}:{Guid.NewGuid()}";
    options.WorkerCount = 1; // debug için 1 iyi
    options.Queues = new[] { "default" };
});
builder.Services.AddMemoryCache();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.ConfigureExceptionHandlingMiddleware();
app.UseHangfireDashboard("/hangfire");

app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers.Authorization.FirstOrDefault();
    var hasAuthHeader = !string.IsNullOrWhiteSpace(authHeader);
    var maskedHeader = MaskAuthorizationHeader(authHeader);

    Log.Information(
        "Auth header check {Method} {Path}: HasAuthorization={HasAuthorization}, Authorization={Authorization}",
        context.Request.Method,
        context.Request.Path,
        hasAuthHeader,
        maskedHeader);

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    await app.MigrateDevAndSeedAsync<AppDbContext>(async (db, sp) =>
    {
        await HostingExtensions.DevSeeder.SeedAsync(db);
    });
}

using (var scope = app.Services.CreateScope())
{
    var recurring = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurring.AddOrUpdate<ExchangeRateHangfireJob>(
     "exchange-rate-refresh",
     x => x.Run(),
     "*/5 * * * *",
     TimeZoneInfo.Local
 );
}


app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context?.User?.Identities.Select(x => x.FindFirst("Id"))?.FirstOrDefault() : null;
    if (username is not null)
    {
        LogContext.PushProperty("UserId", username.Value.ToString());
    }
    await next();
});

app.MapControllers();

app.Run();

static string MaskAuthorizationHeader(string? authorization)
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
        return $"{value.Split(' ')[0]} len={token.Length}";
    }

    var prefix = value.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase) ? "Bearer " : string.Empty;
    return $"{prefix}{token[..6]}...{token[^6..]} len={token.Length}";
}

static void EnsureConfiguredDatabasesExist(IConfiguration configuration)
{
    var connectionStrings = new[]
    {
        configuration.GetConnectionString("DefaultConnection"),
        configuration.GetConnectionString("HangfireConnection"),
        configuration.GetConnectionString("LogsDb")
    };

    foreach (var connectionString in connectionStrings.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct())
    {
        EnsureDatabaseExists(connectionString!);
    }
}

static void EnsureDatabaseExists(string connectionString)
{
    var builder = new SqlConnectionStringBuilder(connectionString);
    var databaseName = builder.InitialCatalog;

    if (string.IsNullOrWhiteSpace(databaseName))
    {
        return;
    }

    builder.InitialCatalog = "master";

    using var connection = new SqlConnection(builder.ConnectionString);
    connection.Open();

    using var existsCommand = connection.CreateCommand();
    existsCommand.CommandText = "SELECT DB_ID(@databaseName)";
    existsCommand.Parameters.AddWithValue("@databaseName", databaseName);

    if (existsCommand.ExecuteScalar() is not DBNull and not null)
    {
        return;
    }

    using var createCommand = connection.CreateCommand();
    createCommand.CommandText = $"CREATE DATABASE [{databaseName.Replace("]", "]]")}]";
    createCommand.ExecuteNonQuery();
}

