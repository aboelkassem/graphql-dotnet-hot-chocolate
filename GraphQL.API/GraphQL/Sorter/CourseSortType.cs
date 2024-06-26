using GraphQL.API.GraphQL.Queries.Types;
using HotChocolate.Data.Sorting;

namespace GraphQL.API.GraphQL.Sorter
{
    public class CourseSortType : SortInputType<CourseType>
    {
        protected override void Configure(ISortInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(x => x.Id);
            descriptor.Ignore(x => x.InstructorId);
            descriptor.Field(x => x.Name).Name("CourseName");

            base.Configure(descriptor);
        }
    }
}
