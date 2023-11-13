using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Countries;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Country
{
    public class GetCountriesQueryHandler : IQueryHandler<GetCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<CountryDto>>(_context.Countries));
        }
    }
}
