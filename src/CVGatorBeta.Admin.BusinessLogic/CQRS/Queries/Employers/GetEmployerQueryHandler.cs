using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employers
{
    public class GetEmployerQueryHandler : IQueryHandler<GetEmployerQuery, EmployerDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetEmployerQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<EmployerDto> Handle(GetEmployerQuery query, CancellationToken cancellationToken)
        {
            var employer = _context.Employers.FirstOrDefault(x => x.EmployerId == query.EmployerId);
            return Task.FromResult(_mapper.Map<EmployerDto>(employer)); 
        }
    }
}
