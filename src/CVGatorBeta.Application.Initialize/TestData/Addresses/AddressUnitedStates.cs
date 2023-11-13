namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressUnitedStates : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: " Houston", Street: " Burnside Avenue"),
                (City: "New York", Street: "Turkey Pen Road"),
                (City: "Las Vegas", Street: "Hall Street"),
                (City: "San Antonio", Street: "Todds Lane"),
                (City: "Portland", Street: "Gateway Road"),
                (City: "Sidney", Street: "Ingram Street"),
                (City: "Long Island City", Street: "Cantebury Drive"),
                (City: "Chicago", Street: "Flinderation Road"),
            };
        }
    }
}
