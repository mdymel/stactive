using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Stactive
{
    public class StactiveMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public StactiveMiddleware(RequestDelegate next, ILogger<StactiveMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            // Call the next delegate/middleware in the pipeline
            await _next(context);
            sw.Stop();

            _logger.LogInformation($"Request {context.Request.Path} took {sw.ElapsedMilliseconds}ms");
        }
    }
}
