using GraphQL.API.Data;
using GraphQL.API.GraphQL.DataLoaders;
using GraphQL.API.Repositories;
using GraphQL.API.StartupExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    //options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddDbContextFactory<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("School")),
    lifetime: ServiceLifetime.Scoped);
builder.Services
        .AddScoped<ICoursesRepository, CoursesRepository>()
        .AddScoped<IInstructorsRepository, InstructorsRepository>()
        .AddScoped<InstructorDataLoader>();

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
