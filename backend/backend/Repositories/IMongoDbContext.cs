using MongoDB.Driver;

namespace backend.Repositories
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
        void DropDatabase(string databaseName);
    }
}