using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class GetCandidateQuery : IQuery<CandidateDto>
    {
        public Guid CandidateId { get; set; }

        public GetCandidateQuery(Guid candidateId)
        {
            CandidateId = candidateId;
        }
    }
}
