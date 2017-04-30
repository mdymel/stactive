using System.Threading.Tasks;
using MongoDB.Driver;
using Stactive.Core;
using Stactive.Core.Models;

namespace Stactive.MongoDbPersistence
{
    public class MongoDbPersistence : IPersistence
    {
        private readonly IMongoCollection<RequestLog> _collection;

        public MongoDbPersistence(StactiveMongoDb stactiveMongoDb, StactiveMongoOptions options)
        {
            _collection = stactiveMongoDb.GetCollection<RequestLog>(options.RequestLogCollectionName);
        }

        public async Task SaveRequestLog(RequestLog log)
        {
            await _collection
                .InsertOneAsync(log)
                .ConfigureAwait(false);
        }
    }
}