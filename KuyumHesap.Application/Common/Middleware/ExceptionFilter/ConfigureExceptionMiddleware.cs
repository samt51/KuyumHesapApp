using Microsoft.AspNetCore.Builder;

namespace KuyumHesap.Application.Common.Middleware.ExceptionFilter
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
