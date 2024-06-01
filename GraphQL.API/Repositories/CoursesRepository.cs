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

        public async Task<IEnumerable<CourseEntity>> GetAll()
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .Include(c => c.Instructor)
                    .Include(c => c.Students)
                    .ToListAsync();
            }
        }

        public async Task<CourseEntity> GetById(Guid courseId)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .Include(c => c.Instructor)
                    .Include(c => c.Students)
                    .FirstOrDefaultAsync(c => c.Id == courseId);
            }
        }

        public async Task<CourseEntity> Create(CourseEntity course)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseEntity> Update(CourseEntity course)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> Delete(Guid id)
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
