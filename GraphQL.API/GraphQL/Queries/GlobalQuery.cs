using GraphQL.API.Data;
using GraphQL.API.GraphQL.Filters;
using GraphQL.API.GraphQL.Queries.Types;
using GraphQL.API.GraphQL.Sorter;
using GraphQL.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQL.API.GraphQL.Queries
{
    public class GlobalQuery()
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<IEnumerable<ISearchResultType>> Search(string term, [Service(ServiceKind.Resolver)] ApplicationDbContext context)
        {
            IEnumerable<CourseType> courses = await context.Courses
                .Where(c => c.Name.Contains(term))
                .Select(c => new CourseType()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subject = c.Subject,
                    InstructorId = c.InstructorId,
                    CreatorId = c.CreatorId
                })
                .ToListAsync();

            IEnumerable<InstructorType> instructors = await context.Instructors
                .Where(i => i.FirstName.Contains(term) || i.LastName.Contains(term))
                .Select(i => new InstructorType
                {
                    Person = new()
                    {
                        Id = i.Id,
                        FirstName = i.FirstName,
                        LastName = i.LastName
                    },
                    Salary = i.Salary
                })
                .ToListAsync();

            // by using union will return combination of courseType and InstructorType
            return new List<ISearchResultType>()
                .Concat(courses)
                .Concat(instructors);
        }

        // will show warning in playground
        [GraphQLDeprecated("This just a test query, no longer needed.")]
        public string HelloWorld => "Hello World";
    }
}
