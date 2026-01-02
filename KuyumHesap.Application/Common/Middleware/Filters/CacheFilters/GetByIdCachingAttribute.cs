using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace KuyumHesap.Application.Common.Middleware.Filters.CacheFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class GetByIdCachingAttribute<T> : Attribute, IAsyncActionFilter
    {
        private readonly string _keyTemplate;
        private readonly int _minutes;

        // ör: "accountType:{id}"
        public GetByIdCachingAttribute(string keyTemplate, int minutes = 30)
        {
            _keyTemplate = keyTemplate;
            _minutes = minutes;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            if (cache is null)
            {
                await next();
                return;
            }

            var key = BuildKey(context, _keyTemplate);

            // ✅ Cache hit
            if (cache.TryGetValue(key, out T cachedValue) && cachedValue is not null)
            {
                context.Result = new OkObjectResult(cachedValue);
                return;
            }

            var executed = await next();

            // exception veya başarısız status ise cache yazma
            if (executed.Exception != null && !executed.ExceptionHandled)
                return;

            if (executed.Result is ObjectResult obj && obj.StatusCode is >= 400)
                return;

            if (executed.Result is ObjectResult objectResult && objectResult.Value is T value)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_minutes),
                    Priority = CacheItemPriority.Normal
                });
            }
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
