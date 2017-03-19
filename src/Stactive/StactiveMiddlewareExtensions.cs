using Microsoft.AspNetCore.Builder;

namespace Stactive
{
    public static class StactiveMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StactiveMiddleware>();
        }
    }
}
