using GraphQL.API.Data;
using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Repositories
{
    public class InstructorsRepository : IInstructorsRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public InstructorsRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<InstructorEntity> GetById(Guid instructorId)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors.FirstOrDefaultAsync(c => c.Id == instructorId);
            }
        }

        public async Task<IEnumerable<InstructorEntity>> GetManyByIds(IReadOnlyList<Guid> instructorIds)
        {
            using (ApplicationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors
                    .Where(i => instructorIds.Contains(i.Id))
                    .ToListAsync();
            }
        }
    }
}
