using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Stactive
{
    public class StactiveMiddleware
    {
        private readonly RequestDelegate _next;

        public StactiveMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            

            // Call the next delegate/middleware in the pipeline
            return _next(context);
        }
    }
}
