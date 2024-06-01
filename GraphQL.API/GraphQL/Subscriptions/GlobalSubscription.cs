using GraphQL.API.GraphQL.Mutations.Results;
using GraphQL.API.GraphQL.Queries.Types;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL.API.GraphQL.Subscriptions
{
    public class GlobalSubscription
    {
        [Subscribe]
        [Topic]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;


        // Subscribing with parameters
        [Subscribe(With = nameof(SubscribeCourseUpdated))]
        public CourseResult CourseUpdated(Guid courseId, [EventMessage] CourseResult course) => course;

        public ValueTask<ISourceStream<CourseResult>> SubscribeCourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver) 
        {
            // will always listen to this topic/channel name
            var topicName = $"{courseId} {nameof(CourseUpdated)}";
            return topicEventReceiver.SubscribeAsync<CourseResult>(topicName);
        }
    }
}
