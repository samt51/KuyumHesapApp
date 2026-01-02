using KuyumHesap.Api.Common.Filters;
using KuyumHesap.Application;
using KuyumHesap.Application.Common.Middleware.ExceptionFilter;
using KuyumHesap.Infrastructure;
using KuyumHesap.Persistence;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using KuyumHesap.Persistence.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), "Log", autoCreateSqlTable: true, columnOptions: new ColumnOptions
    {
        AdditionalColumns = new Collection<SqlColumn>
        {
            new SqlColumn("UserId",System.Data.SqlDbType.VarChar)
        }
    })
     .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
builder.Services.AddMemoryCache();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureExceptionHandlingMiddleware();
app.UseAuthentication();
app.UseAuthorization();

await app.MigrateDevAndSeedAsync<AppDbContext>(async (db, sp) =>
{
    await HostingExtensions.DevSeeder.SeedAsync(db);
});


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
