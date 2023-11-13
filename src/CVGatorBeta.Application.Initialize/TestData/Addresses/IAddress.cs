namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal interface IAddress
    {
        List<(string City, string Street)>  GetAddresses();
    }
}
