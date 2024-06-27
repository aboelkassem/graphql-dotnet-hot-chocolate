namespace GraphQL.API.GraphQL.Queries.Types
{
    public record PersonType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    };
}
