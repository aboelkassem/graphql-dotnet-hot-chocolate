using GraphQL.API.Models;

namespace GraphQL.API.Data;

public static class InitialData
{
    public static void Seed(this ApplicationDbContext dbContext)
    {
        if (dbContext.Products.Any())
            return;

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Mountain Walkers",
            Description = "Use these sturdy shoes to pass any mountain range with ease.",
            Price = 219.5m,
            Rating = 4,
            Type = ProductType.Boots,
            Stock = 12,
            PhotoFileName = "shutterstock_66842440.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "Comfortable for all day trekking",
                    Review = "Very comfortable for a full day outing"
                },
                new ProductReviewEntity()
                {
                    Title = "What a piece a' junk",
                    Review = "The laces come off like 25 times a day. Am i supposed to spend my time tying them or trekking on them?"
                },
                new ProductReviewEntity()
                {
                    Title = "A decent pair",
                    Review = "They are good and do their job well. Could have been little less costlier to make it more competetive."
                },
            }
        });

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Army Slippers",
            Description = "For your everyday marches in the army.",
            Price = 125.9m,
            Rating = 3,
            Type = ProductType.Boots,
            Stock = 56,
            PhotoFileName = "shutterstock_222721876.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "A veteran's delight",
                    Review = "Very comfortable for a relaxing evening."
                },
                new ProductReviewEntity()
                {
                    Title = "Good value for money.",
                    Review = "They are nice for the price they have to offer."
                },
                new ProductReviewEntity()
                {
                    Title = "A decent pair",
                    Review = "They are good and do their job well."
                },
            }
        });

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Backpack Deluxe",
            Description = "This backpack can survive any tornado.",
            Price = 199.99m,
            Rating = 5,
            Type = ProductType.ClimbingGear,
            Stock = 66,
            PhotoFileName = "shutterstock_6170527.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "A hogger's heaven",
                    Review = "I hog a lot of luggage and it provides ample space for it."
                },
                new ProductReviewEntity()
                {
                    Title = "Very costly.",
                    Review = "After buying it after saving for it for a year, I don't really feel it is worth it."
                },
                new ProductReviewEntity()
                {
                    Title = "A tough nut.",
                    Review = "Guess what? I was in a tornado and it survived well enough for me to write about it."
                },
            }
        });

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Climbing Kit",
            Description = "Anything you need to climb the mount Everest.",
            Price = 299.5m,
            Rating = 5,
            Type = ProductType.ClimbingGear,
            Stock = 3,
            PhotoFileName = "shutterstock_48040747.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "Broke my crown.",
                    Review = "I broke my crown when it snapped, Jill came tumbling after."
                },
                new ProductReviewEntity()
                {
                    Title = "What a piece a' junk",
                    Review = "Don't waste your money on this one."
                },
                new ProductReviewEntity()
                {
                    Title = "Will only get you through smooth whether.",
                    Review = "No strings to latch onto in case it gets wet. Would'nt bet my life on it in rough weather."
                },
            }
        });

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Blue Racer",
            Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
            Price = 350m,
            Rating = 5,
            Type = ProductType.Kayaks,
            Stock = 8,
            PhotoFileName = "shutterstock_441989509.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "Good for beginners",
                    Review = "Nice confidence builder for ameteurs."
                },
                new ProductReviewEntity()
                {
                    Title = "Nothing to challenge for an experienced kayaker.",
                    Review = "Already pretty fast. Does'nt pose any challenge for your body to overcome it."
                },
                new ProductReviewEntity()
                {
                    Title = "Very costly.",
                    Review = "Very costly for the function it serves."
                },
            }
        });

        dbContext.Products.Add(new ProductEntity
        {
            Name = "Orange Demon",
            Description = "One person kayak with hyper boost button.",
            Price = 450m,
            Rating = 2,
            Type = ProductType.Kayaks,
            Stock = 1,
            PhotoFileName = "shutterstock_495259978.jpg",
            IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
            ProductReviews = new List<ProductReviewEntity>()
            {
                new ProductReviewEntity()
                {
                    Title = "Nice but not for everyone.",
                    Review = "This is for experienced campaigners and not for average joe kaykakers."
                },
                new ProductReviewEntity()
                {
                    Title = "Beware Amateurs.",
                    Review = "Newbies make the mistake of overestimating themselves and buying it ahead of time."
                },
                new ProductReviewEntity()
                {
                    Title = "Tendency to overuse the hyper-booster",
                    Review = "As a newcomer, it helped me to move to next level. Although at the beginning I did have the tendency to overuse the booster."
                },
            }
        });

        dbContext.SaveChanges();
    }
}
