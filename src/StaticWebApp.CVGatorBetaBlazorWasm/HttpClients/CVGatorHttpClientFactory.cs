using CVGatorBeta.DTO.Interfaces;

namespace StaticWebApp.CVGatorBetaBlazorWasm.HttpClients
{
    public class CVGatorHttpClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CVGatorHttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public CVGatorAdminHttpClient<TDto> Get<TDto>() where TDto : IHttpClientDto, new()
        {
            return new CVGatorAdminHttpClient<TDto>(_httpClientFactory.CreateClient(HttpClientsExtension.CVGatorAdminHttpClient));
        }
    }
}
