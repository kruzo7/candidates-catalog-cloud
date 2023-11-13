using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Countries
{
    public class GetCountriesQuery : IQuery<IEnumerable<CountryDto>>
    {
        public GetCountriesQuery()
        {
        }
    }
}
