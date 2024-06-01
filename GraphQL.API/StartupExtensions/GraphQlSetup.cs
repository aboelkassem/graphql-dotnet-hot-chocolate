using GraphQL.API.GraphQL;
using GraphQL.API.Options;

namespace GraphQL.API.StartupExtensions
{
    public static class GraphQlSetup
    {
        public static IServiceCollection AddGraphQlAPI(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddGraphQLServer()
                .AddQueryType<GlobalQuery>();
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
