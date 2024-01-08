using System.Linq.Expressions;

namespace Baker.DataAccessLayer.Repository.Abstract
{
    public interface IMongoGenericRepository<T> where T : class
    {
        public Task DeleteAsync(string id);
        public Task UpdateAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetFilteredResultAsync(Expression<Func<T, bool>> predicate);
        public Task<T> GetByIdAsync(string id);
        public Task CreateAsync(T entity);
    }
}