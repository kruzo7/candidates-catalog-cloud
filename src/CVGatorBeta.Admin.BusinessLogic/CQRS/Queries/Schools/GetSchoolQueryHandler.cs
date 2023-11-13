using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Schools
{
    public class GetSchoolQueryHandler : IQueryHandler<GetSchoolQuery, SchoolDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetSchoolQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<SchoolDto> Handle(GetSchoolQuery query, CancellationToken cancellationToken)
        {
            var school = _context.Schools.FirstOrDefault(x => x.SchoolId == query.SchoolId);
            return Task.FromResult(_mapper.Map<SchoolDto>(school)); 
        }
    }
}
