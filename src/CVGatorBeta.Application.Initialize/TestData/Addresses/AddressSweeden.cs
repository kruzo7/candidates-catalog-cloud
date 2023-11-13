namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressSweeden : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "SkÄrhamn", Street: "Södra Kroksdal"),
                (City: "GÄllstad", Street: "Sörbylund"),
                (City: "Skillingaryd", Street: "Idvägen"),
                (City: "Berga", Street: "Lantmannagatan"),
                (City: "Sibbhult", Street: "Dadelvägen"),
                (City: "Åsunden", Street: "Sörbylund"),
            };
        }
    }
}
