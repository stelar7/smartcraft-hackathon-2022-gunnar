using backend.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Repositories
{
    /// <summary>
    /// The data repository for TEntity
    /// </summary>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IBaseModel
    {
        /// <summary>
        /// The relevant data collection in the database context the repository operates on
        /// </summary>
        protected readonly IMongoCollection<TEntity> collection;
        /// <summary>
        /// The database context the repository operates on
        /// </summary>
        protected readonly IMongoDbContext context;

        private const int _maxRetries = 5;

        /// <summary>
        /// Constructs a repository with the requirements 
        /// </summary>
        /// <param name="dbContext">The database context the repository operates on</param>
        /// <param name="user">User information for the database</param>
        public BaseRepository(IMongoDbContext dbContext)
        {
            context = dbContext;
            collection = context.GetCollection<TEntity>();
        }

        private TEntity UpdateEntityWithCreatedFields(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = Guid.Empty;
            return entity;
        }

        private TEntity UpdateEntityWithUpdatedFields(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = Guid.Empty;
            return entity;
        }
        /// <summary>
        /// Deletes a given record, identified by id
        /// </summary>
        /// <param name="recordId">The id of the record to delete</param>
        /// <param name="hardDelete">Indicates whether the record is to actually be deleted or simply marked for deletion</param>
        /// <returns>The deleted record</returns>
        public async Task<TEntity> DeleteRecord(Guid recordId, bool hardDelete)
        {
            return await RetryWrapper(async () => await DeleteRecordInternal(recordId, hardDelete));
        }

        protected virtual async Task<TEntity> DeleteRecordInternal(Guid recordId, bool hardDelete)
        {
            TEntity entity = await GetRecord(recordId);
            if (entity.Deleted)
            {
                throw new InvalidOperationException($"{typeof(TEntity).Name} {recordId} is already deleted");
            }
            entity.Deleted = true;
            if (hardDelete)
            {
                collection.FindOneAndDelete(IdFilter(recordId));
            }
            else
            {
                entity = UpdateEntityWithUpdatedFields(entity);
                entity = await UpsertRecord(recordId, entity);
            }
            return entity;
        }

        /// <summary>
        /// Gets a record, identified by id
        /// </summary>
        /// <param name="recordId">The id of the record to get</param>
        /// <returns>The record</returns>
        public async Task<TEntity> GetRecord(Guid recordId)
        {
            return await RetryWrapper(async () => await GetRecordInternal(recordId));
        }

        protected virtual async Task<TEntity> GetRecordInternal(Guid recordId)
        {
            IAsyncCursor<TEntity> list = await collection.FindAsync(IdFilter(recordId));
            TEntity entity = list.FirstOrDefault();
            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, recordId);
            }
            return entity;
        }

        /// <summary>
        /// Gets a list of records, limited by the given paging information
        /// </summary>
        /// <param name="paging">The paging information for the request</param>
        /// <returns>A list of records</returns>
        public async Task<List<TEntity>> GetRecords()
        {
            return await RetryWrapper(async () => await GetRecordsInternal());
        }

        protected async virtual Task<List<TEntity>> GetRecordsInternal()
        {
            var list = await collection.AsQueryable()
                .Where(entity => entity.Deleted == false)
                .ToListAsync();
            return list;
        }

        /// <summary>
        /// Gets the first record matching the given criteria
        /// </summary>
        /// <param name="fieldName">The name of the field to filter on</param>
        /// <param name="fieldValue">The value of the field to filter on</param>
        /// <returns>The first record matching the given criteria</returns>
        public async Task<TEntity> GetFirstRecord(string fieldName, string fieldValue)
        {
            return await RetryWrapper(async () => await GetFirstRecordInternal(fieldName, fieldValue));
        }

        protected virtual async Task<TEntity> GetFirstRecordInternal(string fieldName, string fieldValue)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(fieldName, fieldValue);
            IAsyncCursor<TEntity> list = await collection.FindAsync(filter);
            TEntity entity = await list.FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, fieldName, fieldValue);
            }
            return entity;
        }

        /// <summary>
        /// Gets a list of records matching the given criteria
        /// </summary>
        /// <param name="fieldName">The name of the field to filter on</param>
        /// <param name="fieldValue">The value of the field to filter on</param>
        /// <returns>A list of records matching the given criteria</returns>
        public async Task<List<TEntity>> GetRecords(string fieldName, string fieldValue)
        {
            return await RetryWrapper(async () => await GetRecordsInternal(fieldName, fieldValue));
        }

        protected virtual async Task<List<TEntity>> GetRecordsInternal(string fieldName, string fieldValue)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(fieldName, fieldValue);
            IAsyncCursor<TEntity> matches = await collection.FindAsync(filter);
            return await matches.ToListAsync();
        }

        /// <summary>
        /// Inserts a record with the given data
        /// </summary>
        /// <param name="record">The data to insert as a record</param>
        /// <returns>The inserted record</returns>
        public async Task<TEntity> InsertRecord(TEntity record)
        {
            return await RetryWrapper(async () => await InsertRecordInternal(record));
        }

        protected virtual async Task<TEntity> InsertRecordInternal(TEntity record)
        {
            try
            {
                record = UpdateEntityWithCreatedFields(record);
                record = UpdateEntityWithUpdatedFields(record);
                await collection.InsertOneAsync(record);
            }
            catch (MongoWriteException ex)
            {
                if (ex.Message.ToUpper().Contains("DUPLICATE"))
                {
                    throw new DuplicateException("A record with provided Id already exists", ex);
                }
                throw;
            }
            return await GetRecord(record.Id);
        }

        /// <summary>
        /// Upserts a record with the given data
        /// </summary>
        /// <param name="recordId">The id of the record to upsert</param>
        /// <param name="record">The data to insert as a record</param>
        /// <returns>The upserted record</returns>
        public async Task<TEntity> UpsertRecord(Guid recordId, TEntity record)
        {
            return await RetryWrapper(async () => await UpsertRecordInternal(recordId, record));
        }

        protected virtual async Task<TEntity> UpsertRecordInternal(Guid recordId, TEntity record)

        {
            if (Guid.Empty.Equals(record.Id))
            {
                record.Id = recordId;
                record = UpdateEntityWithCreatedFields(record);
            }
            record = UpdateEntityWithUpdatedFields(record);
            await collection.ReplaceOneAsync(IdFilter(recordId), record, new ReplaceOptions { IsUpsert = true });
            return await GetRecord(record.Id);
        }

        /// <summary>
        /// Upserts a list of records with the given data
        /// </summary>
        /// <param name="records">The list of records to be updated/added</param>
        public async Task<bool> BulkUpsert(List<TEntity> records)
        {
            return await RetryWrapper(async () => await BulkUpsertInternal(records));
        }

        protected virtual async Task<bool> BulkUpsertInternal(List<TEntity> records)
        {
            bool success;
            List<ReplaceOneModel<TEntity>> listofUpserts = new();
            foreach (var record in records)
            {
                UpdateEntityWithUpdatedFields(record);
                if (record.CreatedDate == DateTime.MinValue)
                {
                    UpdateEntityWithCreatedFields(record);
                }
                ReplaceOneModel<TEntity> replaceOneModel = new(IdFilter(record.Id), record)
                {
                    IsUpsert = true
                };
                listofUpserts.Add(replaceOneModel);
            }
            await collection.BulkWriteAsync(listofUpserts);
            success = true;
            return success;
        }

        /// <summary>
        /// Filters the repository by id
        /// </summary>
        /// <param name="recordId">The record id on which to filter</param>
        /// <returns>A filter definition for the repostory to use in further requests</returns>
        protected static FilterDefinition<TEntity> IdFilter(Guid recordId)
        {
            return Builders<TEntity>.Filter.Eq("Id", recordId);
        }

        protected async Task<T> RetryWrapper<T>(Func<Task<T>> action, int tryNumber = 1)
        {
            T retVal = default;
            try
            {
                retVal = await action();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("TooManyRequests (429)"))
                {
                    if (tryNumber <= _maxRetries)
                    {
                        Thread.Sleep(1000 * tryNumber);
                        retVal = await RetryWrapper(action, ++tryNumber);
                    }
                }
            }
            return retVal;
        }
    }
}
