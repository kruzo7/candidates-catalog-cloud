using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class UpdateCourseCommand : ICommand
    {
        public Guid CourseId { get; set; }
        public CourseDto Course { get; set; }

        public UpdateCourseCommand(Guid courseId, CourseDto course)
        {
            CourseId = courseId;
            Course = course;
        }
    }
}
