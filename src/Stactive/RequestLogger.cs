using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stactive.Models;

namespace Stactive
{
    public class RequestLogger : IRequestLogger
    {
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
        } 
    }
}