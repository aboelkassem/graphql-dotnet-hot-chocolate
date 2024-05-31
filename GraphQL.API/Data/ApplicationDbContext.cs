using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<ProductReviewEntity> ProductReviews { get; set; }
}
