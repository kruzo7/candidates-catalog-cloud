namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressGreatBritain : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "Chettle", Street: "Graham Road"),
                (City: "New Mill", Street: "Iolaire Road"),
                (City: "Standeford", Street: "Argyll Street"),
                (City: "Winslow", Street: "Folkestone Road"),
                (City: "Willoughby", Street: "Ramsgate Rd"),
                (City: "Knockdow", Street: "Witney Way"),
            };
        }
    }
}
