using AppAny.HotChocolate.FluentValidation;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using GraphQL.API.GraphQL.Mutations.Inputs;
using GraphQL.API.GraphQL.Mutations.Results;
using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.API.Models;
using GraphQL.API.Repositories;
using GraphQL.API.Validators;
using HotChocolate.Subscriptions;
using System.Security.Claims;

namespace GraphQL.API.GraphQL.Mutations
{
    public class GlobalMutation(ICoursesRepository _coursesRepo)
    {
        // Inject services directly to method
        [HotChocolate.Authorization.Authorize]
        public async Task<CourseResult> CreateCourseAsync(
            [UseFluentValidation, UseValidator<CourseTypeInputValidator>] CourseTypeInput courseInput, 
            [Service] ITopicEventSender topicEventSender,
            ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.ID);
            if (string.IsNullOrEmpty(userId))
                throw new GraphQLException(new Error("UserId Not found in user claimns", "USERID_NOT_FOUND"));
            var email = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL);

            var courseDTO = new CourseEntity
            {
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId,
                CreatorId = userId
            };

            courseDTO = await _coursesRepo.CreateAsync(courseDTO);

            var course = new CourseResult
            {
                Id = courseDTO.Id,
                InstructorId = courseDTO.InstructorId,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject
            };

            // raise event to CourseCreated subscription
            await topicEventSender.SendAsync(nameof(GlobalSubscription.CourseCreated), course);

            return course;
        }

        [HotChocolate.Authorization.Authorize]
        public async Task<CourseResult> UpdateCourseAsync(
            Guid courseId,
            [UseFluentValidation, UseValidator<CourseTypeInputValidator>] CourseTypeInput courseInput, 
            [Service] ITopicEventSender topicEventSender)
        {
            if (courseId == Guid.Empty)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

            var courseDTO = new CourseEntity
            {
                Id = courseId,
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId,
            };

            courseDTO = await _coursesRepo.UpdateAsync(courseDTO);

            var course = new CourseResult
            {
                Id = courseDTO.Id,
                InstructorId = courseDTO.InstructorId,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject
            };

            // raise event to courseUpdated subscription
            var updateCourseTopic = $"{courseId} {nameof(GlobalSubscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);

            return course;
        }

        [HotChocolate.Authorization.Authorize(Policy = "IsAdminPolicy")]
        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            try
            {
                return await _coursesRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
