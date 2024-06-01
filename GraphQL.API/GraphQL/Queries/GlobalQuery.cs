﻿using GraphQL.API.GraphQL.Queries.Types;

namespace GraphQL.API.GraphQL.Queries
{
    public class GlobalQuery
    {
        public IEnumerable<CourseType> GetCourses()
        {
            return new List<CourseType>()
            {
                new CourseType
                (
                    Id: Guid.NewGuid(),
                    Name: "C#",
                    Subject: Common.Enums.SubjectEnum.Science,
                    Instructor: new
                    (
                        Person: new(Id: Guid.NewGuid(), FirstName: "John", LastName: "Doe"),
                        Salary: 1500
                    )
                )
            };
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(100);
            return new CourseType
                (
                    Id: id,
                    Name: "C#",
                    Subject: Common.Enums.SubjectEnum.Science,
                    Instructor: new
                    (
                        Person: new(Id: Guid.NewGuid(), FirstName: "John", LastName: "Doe"),
                        Salary: 1500
                    )
                );
        }

        // will show warning in playground
        [GraphQLDeprecated("This just a test query, no longer needed.")]
        public string HelloWorld => "Hello World";
    }
}