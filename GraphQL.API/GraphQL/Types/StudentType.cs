namespace GraphQL.API.GraphQL.Types
{
    public record StudentType
    (
        PersonType Person,

        [GraphQLName("gpa")]
        [GraphQLDescription("The student's GPA")]
        double GPA
    );
}
