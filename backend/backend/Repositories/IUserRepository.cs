using backend.Models;

namespace backend.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        System.Threading.Tasks.Task UpdateScores(Guid id, int score);
        System.Threading.Tasks.Task SetActiveTask(Guid userId, Guid taskId);
    }
}