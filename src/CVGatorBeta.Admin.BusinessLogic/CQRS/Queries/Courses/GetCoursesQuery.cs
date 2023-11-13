using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Courses
{
    public class GetCoursesQuery : IQuery<IEnumerable<CourseDto>>
    {
        public GetCoursesQuery()
        {
        }
    }
}
