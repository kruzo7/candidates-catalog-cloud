namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressIndia : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "Mumbai", Street: "Plaza Asiad, S V Rd, Santacruz (west)"),
                (City: "Mumbai", Street: "Embee Apt, Saibaba Nagar, Borivali (west)"),
                (City: "Delhi", Street: "Old Lajpat Rai Market"),
                (City: "Bangalore", Street: "Singanapalya"),
                (City: "Vadodara", Street: "Parshva Complex, Ellora Park"),
                (City: "Kolkata", Street: "Mukhram Kanoria Road, Howrah"),
            };
        }
    }
}
