using MongoDB.Driver;
using Stactive.Core;
using Stactive.Core.Models;

namespace Stactive.MongoDbPersistence
{
    public class StactiveMongoDb
    {
        private static MongoClient _client;
        private static string _databaseName;

        public static void Initialize(StactiveMongoOptions options)
        {
            _client = new MongoClient(options.ConnectionString);
            _databaseName = options.DatabaseName;

            CreateIndexes(options);
        }

        private static void CreateIndexes(StactiveMongoOptions options)
        {
            var instance = new StactiveMongoDb();
            var requestLogs = instance.GetCollection<RequestLog>(options.RequestLogCollectionName);

            requestLogs.Indexes.CreateMany(new[]
            {
                new CreateIndexModel<RequestLog>(Builders<RequestLog>.IndexKeys.Ascending(x => x.Url)),
                new CreateIndexModel<RequestLog>(Builders<RequestLog>.IndexKeys.Ascending(x => x.UserId)),
            });
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (_client == null || _databaseName == null) throw new StactiveException("StactiveMongoDb has not been initialized");

            var database = _client.GetDatabase(_databaseName);
            return database.GetCollection<T>(collectionName);
        }
    }
}