namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressPoland : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "Warszawa", Street: "Krucza"),
                (City: "Białystok", Street: "Lipowa"),
                (City: "Lublin", Street: "Poranna"),
                (City: "Łódź", Street: "Rafowa"),
                (City: "Kraków", Street: "Cedrowa"),
                (City: "Poznań", Street: "Bitwy pod Studziankami"),
                (City: "Gdynia", Street: "Goździkowa"),
                (City: "Wrocław", Street: "Krasińskiego Zygmunta"),
                (City: "Rzeszów", Street: "Witkacego"),
            };
        }
    }
}
