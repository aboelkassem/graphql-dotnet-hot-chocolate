using GraphQL.API.Enums;
using GraphQL.API.GraphQL.DataLoaders;
using GraphQL.API.Models;

namespace GraphQL.API.GraphQL.Queries.Types
{
    public record CourseType
    (
        Guid Id,
        string Name,
        SubjectEnum Subject,
        Guid InstructorId
    )
    {
        [GraphQLNonNullType] // cannot return this value as null
        //
        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            InstructorEntity instructorDTO = await instructorDataLoader.LoadAsync(InstructorId, CancellationToken.None);

            return new InstructorType(
                    Person: new(
                        Id: instructorDTO.Id,
                        FirstName: instructorDTO.FirstName,
                        LastName: instructorDTO.LastName),
                    instructorDTO.Salary);
        }
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();

        public string Description()
        {
            // Call DB
            return $"{Name} is a {Subject} course";
        }
    };
}
