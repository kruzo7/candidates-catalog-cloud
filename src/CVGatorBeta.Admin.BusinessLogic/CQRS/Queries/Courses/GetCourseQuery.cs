using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Courses
{
    public class GetCourseQuery : IQuery<CourseDto>
    {
        public Guid CourseId { get; set; }

        public GetCourseQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
