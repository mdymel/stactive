using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Stactive.Loggers;

namespace Stactive
{
    public static class StactiveMiddlewareExtensions
    {
        public static IApplicationBuilder UseStactive(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StactiveMiddleware>();
        }

        public static IServiceCollection AddStactive(this IServiceCollection services)
        {
            services.AddTransient<IRequestLogger, RequestLogger>();
            return services;
        }
    }
}
