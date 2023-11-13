using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Candidates;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates
{
    public class GetCandidateQueryHandler : IQueryHandler<GetCandidateQuery, CandidateDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCandidateQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<CandidateDto> Handle(GetCandidateQuery query, CancellationToken cancellationToken)
        {
            var candidate = _context.Candidates
                .Include(x => x.CandidatesAddress).ThenInclude(x => x!.Country)
                .Include(x => x.CandidatesEmployers).ThenInclude(x => x.Employer)
                .Include(x => x.CandidatesCourses).ThenInclude(x => x.Course)
                .Include(x => x.CandidatesCertificates).ThenInclude(x => x.Certificate)
                .Include(x => x.CandidatesSchools).ThenInclude(x => x.School)
                .Include(x => x.CandidatesCategories).ThenInclude(x => x.Category)
                .Include(x => x.CandidatesFiles).ThenInclude(x => x.File)
                .FirstOrDefault(x => x.CandidateId == query.CandidateId);

            return Task.FromResult(_mapper.Map<CandidateDto>(candidate));
        }
    }
}
