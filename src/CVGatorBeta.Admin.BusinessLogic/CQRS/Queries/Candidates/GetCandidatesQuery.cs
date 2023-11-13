using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class GetCandidatesQuery : IQuery<IEnumerable<CandidateDto>>
    {
        public GetCandidatesQuery()
        {            
        }
    }
}
