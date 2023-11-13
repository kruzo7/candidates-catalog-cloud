using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Schools
{
    public class GetSchoolQuery : IQuery<SchoolDto>
    {
        public Guid SchoolId { get; set; }

        public GetSchoolQuery(Guid schoolId)
        {
            SchoolId = schoolId;
        }
    }
}
