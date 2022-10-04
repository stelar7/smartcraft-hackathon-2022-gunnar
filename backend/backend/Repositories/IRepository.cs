using backend.Models;

namespace backend.Repositories
{
    public interface IRepository<T> where T : IBaseModel
    {
        Task<T> InsertRecord(T record);
        Task<T> UpsertRecord(Guid recordId, T record);
        Task<bool> BulkUpsert(List<T> records);
        Task<T> DeleteRecord(Guid recordId, bool hardDelete);
        Task<List<T>> GetRecords();
        Task<T> GetRecord(Guid recordId);
        Task<T> GetFirstRecord(string fieldName, string fieldValue);
        Task<List<T>> GetRecords(string fieldName, string fieldValue);
    }
}