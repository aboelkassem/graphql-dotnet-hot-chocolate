using GraphQL.API.Data;
using GraphQL.API.Repositories;
using GraphQL.API.StartupExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    //options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("School")));
builder.Services
        .AddScoped<ICoursesRepository, CoursesRepository>();

builder.Services.AddGraphQlAPI(builder.Configuration);

var app = builder.Build();

var sp = builder.Services.BuildServiceProvider();
var dbContext = sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
using (ApplicationDbContext context = dbContext.CreateDbContext())
{
    context.Database.Migrate();
    context.Seed();
}

app.UseRouting();
app.UseWebSockets();
app.AddGraphQl(app.Configuration);
app.Run();
