using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<InstructorEntity> Instructors { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
}
