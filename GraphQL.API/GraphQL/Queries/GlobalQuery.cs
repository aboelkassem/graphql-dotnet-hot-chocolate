using GraphQL.API.GraphQL.Queries.Types;
using GraphQL.API.Repositories;

namespace GraphQL.API.GraphQL.Queries
{
    public class GlobalQuery(ICoursesRepository _coursesRepo)
    {
        public async Task<IEnumerable<CourseType>> GetCoursesAsync()
        {
            var coursesDTOs = await _coursesRepo.GetAllAsync();
            return coursesDTOs.Select(c => new CourseType
            (
                Id: c.Id,
                Name: c.Name,
                Subject: c.Subject,
                Instructor: new(
                    Person: new(
                        Id: c.Instructor.Id, 
                        FirstName: c.Instructor.FirstName, 
                        LastName: c.Instructor.LastName), 
                    c.Instructor.Salary)
            ));
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            var coursesDTO = await _coursesRepo.GetByIdAsync(id);
            if (coursesDTO is null)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

            return new CourseType
            (
                Id: coursesDTO.Id,
                Name: coursesDTO.Name,
                Subject: coursesDTO.Subject,
                Instructor: new(
                    Person: new(
                        Id: coursesDTO.Instructor.Id,
                        FirstName: coursesDTO.Instructor.FirstName,
                        LastName: coursesDTO.Instructor.LastName),
                    coursesDTO.Instructor.Salary)
            );
        }

        // will show warning in playground
        [GraphQLDeprecated("This just a test query, no longer needed.")]
        public string HelloWorld => "Hello World";
    }
}
