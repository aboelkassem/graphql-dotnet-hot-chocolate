using GraphQL.API.Enums;
using GraphQL.API.GraphQL.DataLoaders;
using GraphQL.API.Models;

namespace GraphQL.API.GraphQL.Queries.Types
{
    public class CourseType : ISearchResultType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SubjectEnum Subject { get; set; }

        // always project forign keys
        [IsProjected(true)]
        public Guid InstructorId { get; set; } // no need to query it for being assigned

        [GraphQLNonNullType] // cannot return this value as null
        //
        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            InstructorEntity instructorDTO = await instructorDataLoader.LoadAsync(InstructorId, CancellationToken.None);

            return new InstructorType
            {
                Person = new()
                {
                    Id = instructorDTO.Id,
                    FirstName = instructorDTO.FirstName,
                    LastName = instructorDTO.LastName
                },
                Salary = instructorDTO.Salary
            };
        }
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();


        [IsProjected(true)]
        public string? CreatorId { get; set; }

        public async Task<UserType?> Creator([Service] UserDataLoader userDataLoader)
        {
            if (string.IsNullOrEmpty(CreatorId))
                return null;

            return await userDataLoader.LoadAsync(CreatorId, CancellationToken.None);
        }

        public string Description()
        {
            // Call DB
            return $"{Name} is a {Subject} course";
        }
    };
}
