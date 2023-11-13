using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class CreateCandidateCommand : ICommand<Guid>
    {
        public CandidateDto Candidate { get; set; }

        public CreateCandidateCommand(CandidateDto candidate)
        {
            Candidate = candidate;
        }
    }
}
