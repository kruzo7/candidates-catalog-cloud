using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries
{
    public class DeleteCountryCommand : ICommand
    {
        public Guid CountryId { get; set; }

        public DeleteCountryCommand(Guid countryId)
        {
            CountryId = countryId;
        }
    }
}
