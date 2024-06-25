using GraphQL.API.Data;
using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public CoursesRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //public async Task<IEnumerable<CourseEntity>> GetAllAsync()
        //{
        //    // using DbContextFactory will solve the EF concurrency problems when our GraphQL resolvers run in parallel.
        //    using (ApplicationDbContext context = _contextFactory.CreateDbContext())
        //    {
        //        return await context.Courses
        //            .ToListAsync();
        //    }
        //}

        public async Task<CourseEntity> GetByIdAsync(Guid courseId)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .FirstOrDefaultAsync(c => c.Id == courseId);
            }
        }

        public async Task<CourseEntity> CreateAsync(CourseEntity course)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseEntity> UpdateAsync(CourseEntity course)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                CourseEntity course = new()
                {
                    Id = id
                };
                context.Courses.Remove(course);

                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
