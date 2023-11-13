namespace CVGatorBeta.Application.Initialize.TestData.Addresses
{
    internal class AddressFrance : IAddress
    {
        public List<(string City, string Street)> GetAddresses()
        {
            return new List<(string City, string Street)>()
            {
                (City: "Vierzon", Street: "Place du Jeu de Paume"),
                (City: "Cholet", Street: "Ernest Renan"),
                (City: "Lyon", Street: "Banaudon"),
                (City: "Sainte-marie", Street: "Sébastopol"),
                (City: "Paris", Street: "Square de la Couronne"),
            };
        }
    }
}
