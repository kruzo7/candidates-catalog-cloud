namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressHoland : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "Amsterdam", Street: "Lomanstraat"),
                (City: "Steenenkamer", Street: "Steenenkamer"),
                (City: "Haarlem", Street: "Scheepersstraat"),
                (City: "Soest", Street: "De Gouden Ploeg"),
                (City: "Tiel", Street: "Drumptse Parallelweg"),
                (City: "Ridderkerk", Street: "Eemhof"),
                (City: "Oss", Street: "Braakstraat"),
            };
        }
    }
}
