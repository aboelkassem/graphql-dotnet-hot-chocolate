using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using Google.Apis.Auth.OAuth2;
using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Queries.Types;
using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.API.Options;
using Microsoft.Extensions.Configuration;

namespace GraphQL.API.StartupExtensions
{
    public static class GraphQlSetup
    {
        public static IServiceCollection AddGraphQlAPI(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddGraphQLServer()
                .AddQueryType<GlobalQuery>()
                .AddMutationType<GlobalMutation>()
                .AddSubscriptionType<GlobalSubscription>()
                .AddType<CourseType>()
                .AddType<InstructorType>()
                .AddTypeExtension<CourseQuery>()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddAuthorization()
                .AddInMemorySubscriptions(); // you can use Redis for distributed environments https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/subscriptions#redis-provider https://chillicream.com/docs/hotchocolate/v13/distributed-schema/schema-federations


            ConfigureAuthorization(services, configuration);
            ConfigureAthorization(services, configuration);

            return services;
        }

        public static void ConfigureAuthorization(this IServiceCollection services, ConfigurationManager configuration)
        {
            //services.AddAuthentication().AddJwtBearer(  // for asp.net core jwt bearer token

            services.AddSingleton(FirebaseApp.Create());
            services.AddFirebaseAuthentication();
        }

        public static void ConfigureAthorization(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthorization(o =>
            {
                // if has claim with value admin@gmail.com then statisfy this policy,
                o.AddPolicy("IsAdminPolicy", p =>
                    p.RequireClaim(FirebaseUserClaimType.EMAIL, allowedValues: "admin@gmail.com"));
            });
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
