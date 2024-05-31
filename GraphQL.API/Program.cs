using GraphQL.API.Data;
using GraphQL.API.Repositories;
using GraphQL.API.StartupExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    //options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Shop")));

builder.Services
        .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
        .AddScoped<IProductReviewRepository, ProductReviewRepository>();

builder.Services.AddGraphQlAPI(builder.Configuration);

var app = builder.Build();

var sp = builder.Services.BuildServiceProvider();
var dbContext = sp.GetRequiredService<ApplicationDbContext>();
dbContext.Seed();
app.AddGraphQl(app.Configuration);
app.Run();
