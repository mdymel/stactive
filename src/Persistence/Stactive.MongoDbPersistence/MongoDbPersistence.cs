using System.Threading.Tasks;
using MongoDB.Driver;
using Stactive.Core;
using Stactive.Core.Models;

namespace Stactive.MongoDbPersistence
{
    public class MongoDbPersistence : IPersistence
    {
        private readonly IMongoDatabase _database;
        public static string ConnectionString;

        public MongoDbPersistence()
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new StactiveException("MongoDb ConnectionString has not been set");
            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase("stactive");
        }

        public async Task SaveRequestLog(RequestLog log)
        {
            var collection = _database.GetCollection<RequestLog>("requestLog");
            await collection
                .InsertOneAsync(log)
                .ConfigureAwait(false);
        }
    }
}