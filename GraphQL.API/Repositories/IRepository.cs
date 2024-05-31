using System.Linq.Expressions;

namespace GraphQL.API.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

        Task<IQueryable<TEntity>> GetAllAsync<TProperty>(
            Expression<Func<TEntity, bool>> predicate = default!,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath = default!);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(TKey id);
    }
}
