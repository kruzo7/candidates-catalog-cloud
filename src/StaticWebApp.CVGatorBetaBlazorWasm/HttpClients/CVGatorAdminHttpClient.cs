using System.Net.Http.Json;
using CVGatorBeta.DTO.Interfaces;

namespace StaticWebApp.CVGatorBetaBlazorWasm.HttpClients
{
    public class CVGatorAdminHttpClient<TDto> where TDto : IHttpClientDto, new()
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientDto _dto;
        public CVGatorAdminHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _dto = new TDto();
        }

        public async Task<ICollection<TDto>?>GetAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<TDto>>(_dto.ObjRoute); 
        }

        public async Task<TDto?> GetAsync(Guid guidId)
        {
            return await _httpClient.GetFromJsonAsync<TDto>($"{_dto.ObjRoute}/{guidId}");
        }

        public async Task<Guid?> PostAsync(TDto dto)
        {
            using var requestResponse = await _httpClient.PostAsJsonAsync(_dto.ObjRoute, dto);

            var response = await requestResponse.Content.ReadFromJsonAsync<Guid?>();

            return await Task.FromResult(response);
        }

        public async Task<TResponse?> PostAsync<TResponse>(TDto dto)
        {
            using var requestResponse = await _httpClient.PostAsJsonAsync(_dto.ObjRoute, dto);

            var response = await requestResponse.Content.ReadFromJsonAsync<TResponse>();

            return await Task.FromResult(response);
        }

        public async Task<TResponse?> PostAsync<TResponse>(HttpContent content)
        {
            using var requestResponse = await _httpClient.PostAsync(_dto.ObjRoute, content);

            var response = await requestResponse.Content.ReadFromJsonAsync<TResponse>();

            return await Task.FromResult(response);
        }
        public async Task PutAsync(Guid guidId, TDto dto)
        {
            using var response = await _httpClient.PutAsJsonAsync($"{_dto.ObjRoute}/{guidId}", dto);
        }
        public async Task<TResponse?> PutAsync<TResponse>(Guid guidId, TDto dto)
        {
            using var requestResponse = await _httpClient.PutAsJsonAsync($"{_dto.ObjRoute}/{guidId}", dto);

            var response = await requestResponse.Content.ReadFromJsonAsync<TResponse>();            

            return await Task.FromResult(response);
        }
        public async Task DeleteAsync(Guid guidId)
        {
            using var response = await _httpClient.DeleteAsync($"{_dto.ObjRoute}/{guidId}");
        }
    }
}
