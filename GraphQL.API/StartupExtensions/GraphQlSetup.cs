using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.API.Options;

namespace GraphQL.API.StartupExtensions
{
    public static class GraphQlSetup
    {
        public static IServiceCollection AddGraphQlAPI(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddGraphQLServer()
                .AddQueryType<GlobalQuery>()
                .AddMutationType<GlobalMutation>()
                .AddSubscriptionType<GlobalSubscription>()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddInMemorySubscriptions(); // you can use Redis for distributed environments https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/subscriptions#redis-provider https://chillicream.com/docs/hotchocolate/v13/distributed-schema/schema-federations

            return services;
        }

        public static IApplicationBuilder AddGraphQl(this IApplicationBuilder app, IConfiguration configuration)
        {
            GraphQlConfig config = configuration.GetSection("GraphQlConfig").Get<GraphQlConfig>()!;
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL(config.GraphQlApiEndpoint);
                endpoints.MapBananaCakePop(config.UiEndpoint).WithOptions(new()
                {
                    Enable = true,
                    GraphQLEndpoint = config.GraphQlApiEndpoint
                });
            });
            
            return app;
        }
    }
}
