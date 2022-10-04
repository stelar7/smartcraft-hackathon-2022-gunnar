using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace backend.Repositories
{
    public class TaskRepository : BaseRepository<Models.Task>, ITaskRepository
    {
        IUserRepository _userRepository;
        public TaskRepository(IMongoDbContext dbContext, IUserRepository userRepository) : base(dbContext)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Models.Task>> GetRecordsOwnedBy(Guid guid)
        {
            var list = await collection.AsQueryable()
                .Where(entity => entity.Deleted == false && guid == entity.OwnerId && entity.State != Models.States.Completed)
                .ToListAsync();
            return list;
        }

        public async Task<List<Models.Task>> GetAvailableTasks()
        {
            var list = await collection.AsQueryable()
                .Where(entity => entity.Deleted == false && entity.OwnerId == null && entity.State == Models.States.New)
                .ToListAsync();
            return list;
        }

        public async Task<Models.Task> ReserveTask(Guid id, Guid userId)
        {
            Models.Task task = await GetRecord(id);
            task.State = Models.States.Reserved;
            task.OwnerId = userId;
            return await UpsertRecord(id, task);
        }

        public async Task<Models.Task> CompleteTask(Guid id)
        {
            Models.Task task = await GetRecord(id);
            task.State = Models.States.Completed;
            await _userRepository.UpdateScores(task.OwnerId.Value, task.Score);
            return await UpsertRecord(id, task);

        }

        public async Task<Models.Task> PickTask(Guid id)
        {
            Models.Task task = await GetRecord(id);
            task.State = Models.States.Active;
            return await UpsertRecord(id, task);
        }

        public async Task<Models.Task> SetAsActive(Guid id)
        {
            Models.Task task = await GetRecord(id);
            await _userRepository.SetActiveTask(task.OwnerId.Value, task.Id);
            return task;
        }
    }
}
