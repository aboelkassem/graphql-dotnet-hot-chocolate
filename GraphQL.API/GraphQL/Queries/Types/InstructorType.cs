namespace GraphQL.API.GraphQL.Queries.Types
{
    public record InstructorType : ISearchResultType
    {
        public PersonType Person { get; set; }
        public double Salary { get; set; }
    };
}
