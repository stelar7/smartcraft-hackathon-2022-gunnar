using backend.Models;
using MongoDB.Driver;

namespace backend.Repositories
{
    public class MongoDbContext : IMongoDbContext
    {
        readonly IMongoDatabase db;
        readonly MongoClient client;

        public MongoDbContext(IDatabaseSettings settings)
        {
            client = new MongoClient(settings.ConnectionString);
            db = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void DropDatabase(string databaseName)
        {
            client.DropDatabase(databaseName);
        }
    }
}
