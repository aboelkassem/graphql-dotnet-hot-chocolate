using GraphQL.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GraphQL.API.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? Task.FromResult(_context.Set<TEntity>().AsQueryable())
                : Task.FromResult(_context.Set<TEntity>().Where(predicate));
        }

        public Task<IQueryable<TEntity>> GetAllAsync<TProperty>(
            Expression<Func<TEntity, bool>> predicate = default!,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath = default!)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            return predicate == null
                ? Task.FromResult(query.Include(navigationPropertyPath).AsQueryable())
                : Task.FromResult(query.Where(predicate).Include(navigationPropertyPath).AsQueryable());
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(_context.Set<TEntity>().FirstOrDefault(predicate));
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.FindAsync<TEntity>(id);
        }
    }
}
