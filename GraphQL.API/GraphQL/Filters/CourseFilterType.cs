using GraphQL.API.GraphQL.Queries.Types;
using HotChocolate.Data.Filters;

namespace GraphQL.API.GraphQL.Filters
{
    public class CourseFilterType : FilterInputType<CourseType>
    {
        protected override void Configure(IFilterInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(x => x.Students);

            base.Configure(descriptor);
        }
    }
}
