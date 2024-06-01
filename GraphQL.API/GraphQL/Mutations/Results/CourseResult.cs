using GraphQL.API.GraphQL.Common.Enums;

namespace GraphQL.API.GraphQL.Mutations.Results
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SubjectEnum Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
