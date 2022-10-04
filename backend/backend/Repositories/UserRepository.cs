using backend.Models;

namespace backend.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
