using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class CreateCourseCommand : ICommand<Guid>
    {
        public CourseDto Course { get; set; }

        public CreateCourseCommand(CourseDto course)
        {
            Course = course;
        }
    }
}
