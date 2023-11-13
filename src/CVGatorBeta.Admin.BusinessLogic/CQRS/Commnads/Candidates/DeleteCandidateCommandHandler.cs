using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class DeleteCandidateCommandHandler : ICommandHandler<DeleteCandidateCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteCandidateCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand command, CancellationToken cancellationToken)
        {
            var searchCandidate = _context.SearchCandidates.FirstOrDefault(x => x.CandidateId == command.CandidateId);
            if (searchCandidate !=null) _context.SearchCandidates.Remove(searchCandidate); 

            var candidateAddres = _context.CandidatesAddresses.FirstOrDefault(x => x.CandidateId == command.CandidateId);
            if (candidateAddres != null) _context.CandidatesAddresses.Remove(candidateAddres);

            var candidateCategories = _context.CandidatesCategories.Where(x => x.CandidateId == command.CandidateId).AsEnumerable();
            _context.CandidatesCategories.RemoveRange(candidateCategories);

            var candidateCertificates = _context.CandidatesCertificates.Where(x => x.CandidateId == command.CandidateId).AsEnumerable();
            _context.CandidatesCertificates.RemoveRange(candidateCertificates);

            var candidateCourses = _context.CandidatesCourses.Where(x => x.CandidateId == command.CandidateId).AsEnumerable();
            _context.CandidatesCourses.RemoveRange(candidateCourses);

            var candidateEmployers = _context.CandidatesEmployers.Where(x => x.CandidateId == command.CandidateId).AsEnumerable();
            _context.CandidatesEmployers.RemoveRange(candidateEmployers);
            
            var candidateSchools = _context.CandidatesSchools.Where(x => x.CandidateId == command.CandidateId).AsEnumerable();
            _context.CandidatesSchools.RemoveRange(candidateSchools);

            var candidate = _context.Candidates.First(x => x.CandidateId == command.CandidateId);
            _context.Candidates.Remove(candidate);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
