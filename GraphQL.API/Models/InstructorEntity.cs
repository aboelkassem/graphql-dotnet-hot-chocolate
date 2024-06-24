namespace GraphQL.API.Models;

public class InstructorEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double Salary { get; set; }

    public IEnumerable<CourseEntity> Courses { get; set; }
}