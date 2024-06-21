using GraphQL.API.Data;
using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Repositories
{
    public interface IInstructorsRepository
    {
        Task<InstructorEntity> GetById(Guid instructorId);
        Task<IEnumerable<InstructorEntity>> GetManyByIds(IReadOnlyList<Guid> instructorIds);
    }
}
