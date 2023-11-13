using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Application.Initialize.TestData.Addresses;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Countries
    {

        public Countries()
        {
        }
        public List<(Country country, string city, string street)> CreateSampleData(List<Country> countries)
        {
            var sampleAddresses = new List<(Country country, string city, string street)>();

            foreach (var country in countries)
            {
                IAddress address = GetAddress(country);
                AddAddresses(sampleAddresses, country, address);
            }

            return sampleAddresses;
        }
        public List<Country> GetCountries()
        {
            return new List<Country>() {
                new Country() {  CountryName = "Poland" },
                new Country() {  CountryName = "Holand" },
                new Country() {  CountryName = "Great Britain" },
                new Country() {  CountryName = "India" },
                new Country() {  CountryName = "France" },
                new Country() {  CountryName = "Sweeden" },
                new Country() {  CountryName = "United States" },
            };
        }

        private void AddAddresses(List<(Country Country, string City, string Street)> sampleAddresses, Country country, IAddress address)
        {
            var addresses = address.GetAddresses();
            foreach (var item in addresses)
            {
                sampleAddresses.Add(
                    (country, item.City, item.Street));
            }
        }
        
        private IAddress GetAddress(Country country)
        {
            switch (country.CountryName)
            {
                case ("Poland"):
                    return new AddressPoland();
                case ("Holand"):
                    return new AddressHoland();
                case ("Great Britain"):
                    return new AddressGreatBritain();
                case ("India"):
                    return new AddressIndia();
                case ("France"):
                    return new AddressFrance();
                case ("Sweeden"):
                    return new AddressSweeden();
                case ("United States"):
                    return new AddressUnitedStates();
            }

            throw new NotImplementedException();
        }
    }
}
