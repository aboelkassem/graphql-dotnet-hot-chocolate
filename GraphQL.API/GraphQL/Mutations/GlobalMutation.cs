using GraphQL.API.GraphQL.Mutations.Inputs;
using GraphQL.API.GraphQL.Mutations.Results;
using GraphQL.API.GraphQL.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQL.API.GraphQL.Mutations
{
    public class GlobalMutation
    {
        // Inject services directly to method
        public async Task<CourseResult> CreateCourseAsync(CourseTypeInput courseInput, [Service] ITopicEventSender topicEventSender)
        {
            var course = new CourseResult
            {
                Id = Guid.NewGuid(),
                InstructorId = courseInput.InstructorId,
                Name = courseInput.Name,
                Subject = courseInput.Subject
            };

            // raise event to CourseCreated subscription
            await topicEventSender.SendAsync(nameof(GlobalSubscription.CourseCreated), course);

            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid courseId, CourseTypeInput courseInput, [Service] ITopicEventSender topicEventSender)
        {
            if (courseId == Guid.Empty)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

            var course = new CourseResult
            {
                Id = courseId,
                InstructorId = courseInput.InstructorId,
                Name = courseInput.Name,
                Subject = courseInput.Subject
            };

            // raise event to courseUpdated subscription
            var updateCourseTopic = $"{courseId} {nameof(GlobalSubscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);

            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            return true;
        }
    }
}
