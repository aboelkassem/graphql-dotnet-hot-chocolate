namespace GraphQL.API.GraphQL.Queries.Types
{
    public record StudentType
    {
        [GraphQLName("gpa")]
        [GraphQLDescription("The student's GPA")]
        public double GPA { get; set; }

        public PersonType Person { get; set; }
    };
}
