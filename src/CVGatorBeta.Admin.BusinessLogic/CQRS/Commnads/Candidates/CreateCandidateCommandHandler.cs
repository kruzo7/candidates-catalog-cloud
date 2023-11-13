using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ChangeTrackers;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class CreateCandidateCommandHandler : ICommandHandler<CreateCandidateCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;
        private readonly CandidateChangeTracker _candidateChangeTracker;

        public CreateCandidateCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
            _candidateChangeTracker = new CandidateChangeTracker();
        }

        public async Task<Guid> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(command.Candidate);

            await CreateCandidate(candidate, cancellationToken);

            return candidate.CandidateId;
        }
        public async Task CreateCandidate(Candidate candidate, CancellationToken cancellationToken)
        {
            await _context.Candidates.AddAsync(candidate, cancellationToken);
            await CreateSearchCandidate(candidate);

            _context.ChangeTracker.AddAudit();

            _candidateChangeTracker.OnAdd(_context.ChangeTracker);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateSearchCandidate(Candidate candidate)
        {
            var searchCandidate = _mapper.Map<SearchCandidate>(candidate);

            await _context.SearchCandidates.AddAsync(searchCandidate);
        }
    }
}
