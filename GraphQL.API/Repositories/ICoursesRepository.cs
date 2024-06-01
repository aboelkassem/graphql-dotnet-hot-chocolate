using GraphQL.API.Data;
using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<CourseEntity>> GetAll();

        Task<CourseEntity> GetById(Guid courseId);

        Task<CourseEntity> Create(CourseEntity course);

        Task<CourseEntity> Update(CourseEntity course);

        Task<bool> Delete(Guid id);
    }
}
