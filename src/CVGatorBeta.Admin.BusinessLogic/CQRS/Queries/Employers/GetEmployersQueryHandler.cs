using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employers;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employer
{
    public class GetEmployersQueryHandler : IQueryHandler<GetEmployersQuery, IEnumerable<EmployerDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetEmployersQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<EmployerDto>> Handle(GetEmployersQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<EmployerDto>>(_context.Employers));
        }
    }
}
