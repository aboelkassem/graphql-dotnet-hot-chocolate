using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.API.Models;

public class ProductEntity
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public ProductType Type { get; set; }
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int Rating { get; set; }
    public DateTimeOffset IntroducedAt { get; set; }

    [StringLength(100)]
    public string PhotoFileName { get; set; } = string.Empty;

    public ICollection<ProductReviewEntity> ProductReviews { get; set; } = [];
}