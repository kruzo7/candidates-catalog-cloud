using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class DeleteCandidateCommand : ICommand
    {
        public Guid CandidateId { get; set; }

        public DeleteCandidateCommand(Guid candidateId)
        {
            CandidateId = candidateId;
        }
    }
}
