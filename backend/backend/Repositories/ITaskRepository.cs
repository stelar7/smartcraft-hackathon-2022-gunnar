namespace backend.Repositories
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<List<Models.Task>> GetRecordsOwnedBy(Guid guid);
        Task<List<Models.Task>> GetAvailableTasks();
        Task<Models.Task> ReserveTask(Guid id, Guid userId);
        Task<Models.Task> CompleteTask(Guid guid);
        Task<Models.Task> PickTask(Guid guid);
        Task<Models.Task> SetAsActive(Guid guid);
    }
}
