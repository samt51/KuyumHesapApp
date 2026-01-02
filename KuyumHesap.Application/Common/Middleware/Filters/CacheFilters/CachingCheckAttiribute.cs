using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace KuyumHesap.Application.Common.Middleware.Filters.CacheFilters
{
    public class CachingCheckAttiribute<T> : Attribute, IActionFilter
    {
        private readonly string _cacheKey;
        public CachingCheckAttiribute(string cachekey)
        {
            this._cacheKey = cachekey;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var memoryCache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            if (memoryCache != null)
            {
                var value = memoryCache.Get<T>(this._cacheKey);
                if (value is not null)
                {
                    context.Result = new ObjectResult(value);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var memoryCache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            if (memoryCache != null)
            {
                if (context.Result is ObjectResult objectResult)
                {
                    T resultValue = (T)objectResult.Value;
                    memoryCache.Set<T>(_cacheKey, resultValue, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30),


                        Priority = CacheItemPriority.Normal
                    });
                }
            }
        }
    }
}