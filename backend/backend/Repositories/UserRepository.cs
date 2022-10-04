using backend.Models;

namespace backend.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext dbContext) : base(dbContext)
        {
        }

        public async System.Threading.Tasks.Task SetActiveTask(Guid userId, Guid taskId)
        {
            User user = await GetRecord(userId);
            user.ActiveTask = taskId;
            UpsertRecord(user.Id, user);
        }

        public async System.Threading.Tasks.Task UpdateScores(Guid id, int score)
        {
            User user = await GetRecord(id);
            user.ThisMonthsScore += score;
            user.ThisWeeksScore += score;
            user.ThisYearsScore += score;
            user.OverallScore += score;
            await UpsertRecord(user.Id, user);
        }
    }
}
