namespace Stactive.MongoDbPersistence
{
    public class StactiveMongoOptions
    {
        public string ConnectionString { get; private set; } = "mongodb://localhost:27017/";
        public string DatabaseName { get; private set; } = "stactive";
        public string RequestLogCollectionName { get; private set; } = "requestLog";

        public void WithConnectionString(string connectionString) => ConnectionString = connectionString;
        public void WithDatabaseName(string databaseName) => DatabaseName = databaseName;
        public void WithRequestLogCollectionName(string requestLogCollectionName) => RequestLogCollectionName = requestLogCollectionName;
    }
}