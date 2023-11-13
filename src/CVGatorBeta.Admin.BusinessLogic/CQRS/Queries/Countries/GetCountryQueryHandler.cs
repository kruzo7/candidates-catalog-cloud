using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Countries
{
    public class GetCountryQueryHandler : IQueryHandler<GetCountryQuery, CountryDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCountryQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<CountryDto> Handle(GetCountryQuery query, CancellationToken cancellationToken)
        {
            var country = _context.Countries.FirstOrDefault(x => x.CountryId == query.CountryId);
            return Task.FromResult(_mapper.Map<CountryDto>(country)); 
        }
    }
}
