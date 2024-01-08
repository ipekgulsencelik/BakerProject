using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Abstract;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Baker.DataAccessLayer.Repository.Concrete
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : IMongoBaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoGenericRepository(DatabaseSettings databaseSettings)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            var collectionName = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
            _collection = collectionName;
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.ID == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetFilteredResultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.FindOneAndReplaceAsync<T>(x => x.ID == entity.ID, entity);
        }
    }
}