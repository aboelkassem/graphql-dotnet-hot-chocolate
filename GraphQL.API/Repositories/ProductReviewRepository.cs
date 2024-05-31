using GraphQL.API.Data;
using GraphQL.API.Models;

namespace GraphQL.API.Repositories
{
    public class ProductReviewRepository : Repository<ProductReviewEntity, int>, IProductReviewRepository
    {
        private ApplicationDbContext _context;

        public ProductReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<ILookup<int, ProductReviewEntity>> GetReviewsByProductId(IEnumerable<int> productIds)
        {
            return Task.FromResult(_context.ProductReviews
                .Where(r => productIds.Any(pId => pId == r.ProductId))
                .ToLookup(x => x.ProductId));
        }
    }
}
