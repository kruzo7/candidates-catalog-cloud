using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries
{
    public class UpdateCountryCommand : ICommand
    {
        public Guid CountryId { get; set; }
        public CountryDto Country { get; set; }

        public UpdateCountryCommand(Guid countryId, CountryDto country)
        {
            CountryId = countryId;
            Country = country;
        }
    }
}
