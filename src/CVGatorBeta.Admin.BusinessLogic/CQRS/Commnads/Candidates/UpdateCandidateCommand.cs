using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class UpdateCandidateCommand : ICommand
    {
        public Guid CandidateId { get; set; }
        public CandidateDto Candidate { get; set; }

        public UpdateCandidateCommand(Guid candidateId, CandidateDto candidate)
        {
            CandidateId = candidateId;
            Candidate = candidate;
        }

    }
}
