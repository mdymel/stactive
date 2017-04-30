using System;
using Microsoft.Extensions.DependencyInjection;
using Stactive.Core;

namespace Stactive.MongoDbPersistence
{
    public static class StactiveMiddlewareExtensions
    {
        public static IServiceCollection AddStactiveMongoPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPersistence, MongoDbPersistence>();

            if (string.IsNullOrEmpty(connectionString)) throw new StactiveException("ConnectionString cannot be empty");
            MongoDbPersistence.ConnectionString = connectionString;
            return services;
        }
    }

    public class StactiveMongoOptions
    {
        public string ConnectionString { get; set; }
    }
}
