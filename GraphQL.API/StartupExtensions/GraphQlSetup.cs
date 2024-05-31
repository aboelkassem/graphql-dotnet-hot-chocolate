using GraphQL.API.Options;

namespace GraphQL.API.StartupExtensions
{
    public static class GraphQlSetup
    {
        public static IServiceCollection AddGraphQlAPI(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            
            return services;
        }

        public static IApplicationBuilder AddGraphQl(this IApplicationBuilder app, IConfiguration configuration)
        {
            GraphQlConfig config = configuration.GetSection("GraphQlConfig").Get<GraphQlConfig>()!;

            return app;
        }
    }
}
