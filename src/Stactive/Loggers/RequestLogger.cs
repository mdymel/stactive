using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stactive.Core;
using Stactive.Core.Models;

namespace Stactive.Loggers
{
    public class RequestLogger : IRequestLogger
    {
        private readonly IEnumerable<IPersistence> _persistances;

        public RequestLogger(IEnumerable<IPersistence> persistances)
        {
            _persistances = persistances;
        }

        public async Task LogRequest(HttpContext context, long processingTime)
        {
            var requestLog = new RequestLog
            {
                Url = context.Request.Path,
                ResponseStatus = context.Response.StatusCode,
                ContentType = context.Response.ContentType,
                ResponseLength = context.Response.ContentLength,
                ProcessingTime = processingTime
            };

            await Task.WhenAll(_persistances.Select(p =>
                    p.SaveRequestLog(requestLog)))
                .ConfigureAwait(false);
        } 
    }
}