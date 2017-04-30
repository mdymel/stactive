using MongoDB.Driver;
using Stactive.Core;

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
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (_client == null || _databaseName == null) throw new StactiveException("StactiveMongoDb has not been initialized");

            var database = _client.GetDatabase(_databaseName);
            return database.GetCollection<T>(collectionName);
        }
    }
}