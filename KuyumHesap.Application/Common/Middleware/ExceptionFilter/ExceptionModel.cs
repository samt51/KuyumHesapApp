using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KuyumHesap.Application.Common.Middleware.ExceptionFilter
{
    public class ExceptionModel
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LogDetailConsume
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public LogDetailConsume(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
    }
}
