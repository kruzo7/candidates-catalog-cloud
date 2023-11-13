using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class DeleteCourseCommand : ICommand
    {
        public Guid CourseId { get; set; }

        public DeleteCourseCommand(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
