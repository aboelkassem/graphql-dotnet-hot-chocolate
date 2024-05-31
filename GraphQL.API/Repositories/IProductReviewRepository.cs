using GraphQL.API.Models;

namespace GraphQL.API.Repositories
{
    public interface IProductReviewRepository : IRepository<ProductReviewEntity, int>
    {
        Task<ILookup<int, ProductReviewEntity>> GetReviewsByProductId(IEnumerable<int> productIds);
    }
}
