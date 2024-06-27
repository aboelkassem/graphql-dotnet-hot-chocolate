using GraphQL.API.Enums;

namespace GraphQL.API.Models;

public class CourseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SubjectEnum Subject { get; set; }

    public string CreatorId { get; set; }

    public Guid InstructorId { get; set; }
    public InstructorEntity Instructor { get; set; } = default!;

    public IEnumerable<StudentEntity> Students { get; set; }
}