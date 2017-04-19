using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Stactive
{
    public static class StactiveMiddlewareExtensions
    {
        public static IApplicationBuilder UseStactive(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StactiveMiddleware>();
        }

        public static IServiceCollection AddStactive(this IServiceCollection services, Action<StactiveOptions> optionsBuilder)
        {
            services.AddTransient<IRequestLogger, RequestLogger>();

            optionsBuilder.Invoke(Stactive.Options);

            return services;
        }
    }
}
