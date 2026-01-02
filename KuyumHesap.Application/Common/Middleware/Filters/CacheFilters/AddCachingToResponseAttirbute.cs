using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace KuyumHesap.Application.Common.Middleware.Filters.CacheFilters
{
    public class AddCachingToResponseAttirbute : Attribute, IResultFilter
    {
        private readonly string _cacheKey;

        public AddCachingToResponseAttirbute(string cacheKey)
        {
            _cacheKey = cacheKey;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var memoryCache = (IMemoryCache)context.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            if (memoryCache != null)
            {
                memoryCache.Remove(_cacheKey);
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}