namespace GraphQL.API.Models;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double GPA { get; set; }

    public IEnumerable<CourseEntity> Courses { get; set; } = [];
}