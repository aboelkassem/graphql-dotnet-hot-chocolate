namespace GraphQL.API.Middlewares.UseUser
{
    // instead of using [GlobalState("key")]
    // we customize it here with user attribute
    public class UserAttribute : GlobalStateAttribute
    {
        public UserAttribute() : base(UserMiddleware.USER_CONTEXT_DATA_KEY)
        {
        }
    }
}
