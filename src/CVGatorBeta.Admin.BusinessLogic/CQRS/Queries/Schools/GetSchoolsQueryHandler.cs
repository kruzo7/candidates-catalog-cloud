using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Schools;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.School
{
    public class GetSchoolsQueryHandler : IQueryHandler<GetSchoolsQuery, IEnumerable<SchoolDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetSchoolsQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<SchoolDto>> Handle(GetSchoolsQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<SchoolDto>>(_context.Schools));
        }
    }
}
