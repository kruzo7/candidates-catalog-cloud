using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Countries
{
    public class GetCountryQuery : IQuery<CountryDto>
    {
        public Guid CountryId { get; set; }

        public GetCountryQuery(Guid countryId)
        {
            CountryId = countryId;
        }
    }
}
