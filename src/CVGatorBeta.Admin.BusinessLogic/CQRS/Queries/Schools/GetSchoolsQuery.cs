using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Schools
{
    public class GetSchoolsQuery : IQuery<IEnumerable<SchoolDto>>
    {
        public GetSchoolsQuery()
        {
        }
    }
}
