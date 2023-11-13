using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ChangeTrackers;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates
{
    public class UpdateCandidateCommandHandler : ICommandHandler<UpdateCandidateCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;
        private readonly CandidateChangeTracker _candidateChangeTracker;

        public UpdateCandidateCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
            _candidateChangeTracker = new CandidateChangeTracker();
        }

        public async Task<Unit> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(command.Candidate);

            _context.Candidates.Update(candidate);
            UpdateSearchCandidate(candidate);
            
            _context.ChangeTracker.AddAudit();

            _candidateChangeTracker.OnAdd(_context.ChangeTracker);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void UpdateSearchCandidate(Candidate candidate)
        {
            var searchCandidate = _mapper.Map<SearchCandidate>(candidate);

            _context.SearchCandidates.Update(searchCandidate);
        }
    }
}
