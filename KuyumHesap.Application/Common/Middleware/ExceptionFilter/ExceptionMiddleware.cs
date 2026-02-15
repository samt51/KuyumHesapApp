using FluentValidation;
using KuyumHesap.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;
using System.Text.Json;

namespace KuyumHesap.Application.Common.Middleware.ExceptionFilter
{
    public class ExceptionMiddleware : IMiddleware
    {
        private static readonly JsonSerializerOptions JsonOpt = new(JsonSerializerDefaults.Web);

        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var userId = context.User?.FindFirst("Id")?.Value ?? "-";
                using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId }))
                    _logger.LogError(ex.Message, "Unhandled exception"); // ✅ ex'i direkt ver

                await HandleExceptionAsync(context, ex);
            }
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound, // ✅ 400 değil 404 olmalı
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json; charset=utf-8";

            // ✅ ResponseDto<T> oluştur (T burada object olsun)
            ResponseDto<object> response;

            if (exception is ValidationException validationEx)
            {
                var errors = validationEx.Errors.Select(x => x.ErrorMessage).ToList();
                response = new ResponseDto<object>().Fail(errors, statusCode);
            }
            else
            {
                response = new ResponseDto<object>().Fail(exception.Message, statusCode);
            }

            // ✅ JSON olarak yaz
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, JsonOpt));
            // Alternatif: await httpContext.Response.WriteAsJsonAsync(response, JsonOpt);
        }
    }
}
