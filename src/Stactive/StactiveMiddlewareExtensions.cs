using Microsoft.AspNetCore.Builder;

namespace Stactive
{
    public static class StactiveMiddlewareExtensions
    {
        public static IApplicationBuilder UseStactive(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StactiveMiddleware>();
        }
    }
}
