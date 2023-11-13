using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Candidates;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class GetCandidatesQueryHandler : IQueryHandler<GetCandidatesQuery, IEnumerable<CandidateDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCandidatesQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<CandidateDto>> Handle(GetCandidatesQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _mapper.Map<IEnumerable<CandidateDto>>(
                    _context.Candidates
                    ));
        }
    }
}
