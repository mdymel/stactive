using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

// ReSharper disable ConsiderUsingConfigureAwait

namespace Stactive
{
    public class StactiveMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IRequestLogger _requestLogger;

        public StactiveMiddleware(
            RequestDelegate next,
            IRequestLogger requestLogger,
            ILogger<StactiveMiddleware> logger)
        {
            _next = next;
            _logger = logger;

            _requestLogger = requestLogger;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch sw = Stopwatch.StartNew();
            // Call the next delegate/middleware in the pipeline
            await _next(context);
            sw.Stop();

            _logger.LogInformation($"Request {context.Request.Path} took {sw.ElapsedMilliseconds}ms");

            await _requestLogger.LogRequest(context, sw.ElapsedMilliseconds);

            if (context.Items.ContainsKey(Stactive.StactiveEventsKey))
            {
                ProcessEvents(context);
            }
        }

        private void ProcessEvents(HttpContext context)
        {
            var list = context.Items[Stactive.StactiveEventsKey] as List<StactiveEvent>;
            if (list == null) return;

            foreach (StactiveEvent stactiveEvent in list)
            {
                _logger.LogInformation($"Event {stactiveEvent.Id}: {stactiveEvent.Name}");
            }
        }
    }
}
