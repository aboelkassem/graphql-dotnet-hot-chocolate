using GraphQL.API.Models;
using GraphQL.API.Repositories;

namespace GraphQL.API.GraphQL.DataLoaders;

public class InstructorDataLoader : BatchDataLoader<Guid, InstructorEntity>
{
    private readonly IInstructorsRepository _instructorsRepository;

    public InstructorDataLoader(
        IInstructorsRepository instructorsRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options = null)
        : base(batchScheduler, options)
    {
        _instructorsRepository = instructorsRepository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, InstructorEntity>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        IEnumerable<InstructorEntity> instructors = await _instructorsRepository.GetManyByIds(keys);

        return instructors.ToDictionary(i => i.Id);
    }
}
