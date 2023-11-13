using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries
{
    public class CreateCountryCommand : ICommand<Guid>
    {
        public CountryDto Country { get; set; }

        public CreateCountryCommand(CountryDto country)
        {
            Country = country;
        }
    }
}
