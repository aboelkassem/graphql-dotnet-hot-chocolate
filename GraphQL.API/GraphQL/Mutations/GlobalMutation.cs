using GraphQL.API.GraphQL.Mutations.Inputs;
using GraphQL.API.GraphQL.Mutations.Results;

namespace GraphQL.API.GraphQL.Mutations
{
    public class GlobalMutation
    {
        public CourseResult CreateCourse(CourseTypeInput course)
        {
            return new CourseResult 
            {
                Id = Guid.NewGuid(),
                InstructorId = course.InstructorId,
                Name = course.Name,
                Subject = course.Subject
            };
        }

        public CourseResult UpdateCourse(Guid id, CourseTypeInput course)
        {
            if (id == Guid.Empty)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));
            
            return new CourseResult
            {
                Id = id,
                InstructorId = course.InstructorId,
                Name = course.Name,
                Subject = course.Subject
            };
        }

        public bool DeleteCourse(Guid id)
        {
            return true;
        }
    }
}
