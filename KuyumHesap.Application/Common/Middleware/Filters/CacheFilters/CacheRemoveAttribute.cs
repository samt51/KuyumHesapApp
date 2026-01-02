using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace KuyumHesap.Application.Common.Middleware.Filters.CacheFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CacheRemoveAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _keyTemplate;

        public CacheRemoveAttribute(string keyTemplate)
        {
            _keyTemplate = keyTemplate;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executed = await next();

            if (executed.Exception != null && !executed.ExceptionHandled)
                return;

            if (executed.Result is ObjectResult obj && obj.StatusCode is >= 400)
                return;

            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            if (cache is null) return;

            var key = BuildKey(context, _keyTemplate);
            cache.Remove(key);
        }

        private static string BuildKey(ActionExecutingContext ctx, string template)
        {
            var key = template;

            foreach (var arg in ctx.ActionArguments)
                key = key.Replace("{" + arg.Key + "}", arg.Value?.ToString());

            foreach (var rv in ctx.RouteData.Values)
                key = key.Replace("{" + rv.Key + "}", rv.Value?.ToString());

            return key;
        }
    }
}
