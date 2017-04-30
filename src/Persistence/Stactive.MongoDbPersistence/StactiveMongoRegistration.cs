using System;
using Microsoft.Extensions.DependencyInjection;
using Stactive.Core;

namespace Stactive.MongoDbPersistence
{
    public static class StactiveMiddlewareExtensions
    {
        public static IServiceCollection AddStactiveMongoPersistance(this IServiceCollection services, Action<StactiveMongoOptions> options = null)
        {
            services.AddTransient<IPersistence, MongoDbPersistence>();
            
            var stactiveMongoOptions = new StactiveMongoOptions();
            options?.Invoke(stactiveMongoOptions);
            services.AddTransient(c => stactiveMongoOptions);

            StactiveMongoDb.Initialize(stactiveMongoOptions);
            services.AddTransient<StactiveMongoDb>();
            return services;
        }
    }
}
