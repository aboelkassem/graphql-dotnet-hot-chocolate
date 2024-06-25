using GraphQL.API.Models;

namespace GraphQL.API.Repositories
{
    public interface ICoursesRepository
    {
        //Task<IEnumerable<CourseEntity>> GetAllAsync();

        Task<CourseEntity> GetByIdAsync(Guid courseId);

        Task<CourseEntity> CreateAsync(CourseEntity course);

        Task<CourseEntity> UpdateAsync(CourseEntity course);

        Task<bool> DeleteAsync(Guid id);
    }
}
