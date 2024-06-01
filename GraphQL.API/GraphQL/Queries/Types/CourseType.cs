using GraphQL.API.GraphQL.Common.Enums;
using Microsoft.Identity.Client;

namespace GraphQL.API.GraphQL.Queries.Types
{
    public record CourseType
    (
        Guid Id,
        string Name,
        SubjectEnum Subject,

        [GraphQLNonNullType] // cannot return this value as null
        InstructorType Instructor
    )
    {
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();

        public string Description()
        {
            // Call DB
            return $"{Name} is a {Subject} course";
        }
    };
}
