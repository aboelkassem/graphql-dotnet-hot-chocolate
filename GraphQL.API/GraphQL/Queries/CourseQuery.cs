using GraphQL.API.Data;
using GraphQL.API.GraphQL.Filters;
using GraphQL.API.GraphQL.Queries.Types;
using GraphQL.API.GraphQL.Sorter;
using GraphQL.API.Repositories;

namespace GraphQL.API.GraphQL.Queries
{
    [ExtendObjectType(typeof(GlobalQuery))]
    public class CourseQuery(ICoursesRepository _coursesRepo)
    {
        // the ordering is important
        [UseDbContext(typeof(ApplicationDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        [UseFiltering(Type = typeof(CourseFilterType))]
        [UseSorting(Type = typeof(CourseSortType))]
        public IQueryable<CourseType> GetCourses([Service(ServiceKind.Resolver)] ApplicationDbContext context)
        {
            return context.Courses.Select(c => new CourseType
            {
                Id = c.Id,
                Name = c.Name,
                Subject = c.Subject,
                InstructorId = c.InstructorId,
                CreatorId = c.CreatorId,
            });
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        [UseFiltering(Type = typeof(CourseFilterType))]
        [UseSorting(Type = typeof(CourseSortType))]
        public IQueryable<CourseType> GetOffsetCourses([Service(ServiceKind.Resolver)] ApplicationDbContext context)
        {
            return context.Courses.Select(c => new CourseType
            {
                Id = c.Id,
                Name = c.Name,
                Subject = c.Subject,
                InstructorId = c.InstructorId,
                CreatorId = c.CreatorId,
            });
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            var coursesDTO = await _coursesRepo.GetByIdAsync(id);
            if (coursesDTO is null)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

            return new CourseType
            {
                Id = coursesDTO.Id,
                Name = coursesDTO.Name,
                Subject = coursesDTO.Subject,
                InstructorId = coursesDTO.InstructorId,
                CreatorId = coursesDTO.CreatorId,
            };
        }
    }
}
