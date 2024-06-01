using GraphQL.API.Enums;
using GraphQL.API.Models;

namespace GraphQL.API.Data;

public static class InitialData
{
    public static void Seed(this ApplicationDbContext dbContext)
    {
        if (dbContext.Courses.Any() || dbContext.Instructors.Any() || dbContext.Students.Any())
            return;

        // Instructors
        var instructors = new List<InstructorEntity>
    {
        new InstructorEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Salary = 60000
        },
        new InstructorEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            Salary = 65000
        },
        new InstructorEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Albert",
            LastName = "Einstein",
            Salary = 100000
        },
        new InstructorEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Marie",
            LastName = "Curie",
            Salary = 95000
        }
    };

        // Students
        var students = new List<StudentEntity>
    {
        new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Alice",
            LastName = "Johnson",
            GPA = 3.5
        },
        new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Bob",
            LastName = "Brown",
            GPA = 3.2
        },
        new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Charlie",
            LastName = "Davis",
            GPA = 3.8
        },
        new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "Diana",
            LastName = "Miller",
            GPA = 3.9
        }
    };

        // Courses
        var courses = new List<CourseEntity>
    {
        new CourseEntity
        {
            Id = Guid.NewGuid(),
            Name = "Advanced Mathematics",
            Subject = SubjectEnum.Mathematics,
            InstructorId = instructors[0].Id,
            Instructor = instructors[0],
            Students = new List<StudentEntity> { students[0], students[1] }
        },
        new CourseEntity
        {
            Id = Guid.NewGuid(),
            Name = "Introduction to Computer Science",
            Subject = SubjectEnum.Science,
            InstructorId = instructors[1].Id,
            Instructor = instructors[1],
            Students = new List<StudentEntity> { students[2], students[3] }
        },
        new CourseEntity
        {
            Id = Guid.NewGuid(),
            Name = "Physics for Beginners",
            Subject = SubjectEnum.Science,
            InstructorId = instructors[2].Id,
            Instructor = instructors[2],
            Students = new List<StudentEntity> { students[0], students[2] }
        },
        new CourseEntity
        {
            Id = Guid.NewGuid(),
            Name = "History of the Modern World",
            Subject = SubjectEnum.History,
            InstructorId = instructors[3].Id,
            Instructor = instructors[3],
            Students = new List<StudentEntity> { students[1], students[3] }
        }
    };

        // Assign courses to instructors and students
        instructors[0].Courses = new List<CourseEntity> { courses[0] };
        instructors[1].Courses = new List<CourseEntity> { courses[1] };
        instructors[2].Courses = new List<CourseEntity> { courses[2] };
        instructors[3].Courses = new List<CourseEntity> { courses[3] };

        students[0].Courses = new List<CourseEntity> { courses[0], courses[2] };
        students[1].Courses = new List<CourseEntity> { courses[0], courses[3] };
        students[2].Courses = new List<CourseEntity> { courses[1], courses[2] };
        students[3].Courses = new List<CourseEntity> { courses[1], courses[3] };

        // Add entities to the context
        dbContext.Instructors.AddRange(instructors);
        dbContext.Students.AddRange(students);
        dbContext.Courses.AddRange(courses);

        // Save changes to the database
        dbContext.SaveChanges();
    }
}
