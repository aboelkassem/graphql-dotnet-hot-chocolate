using GraphQL.API.Enums;

namespace GraphQL.API.GraphQL.Mutations.Inputs
{
    public class CourseTypeInput
    {
        public string Name { get; set; } = string.Empty;
        public SubjectEnum Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
