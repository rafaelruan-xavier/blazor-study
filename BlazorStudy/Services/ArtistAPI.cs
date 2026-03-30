using ScreenSound.Shared.Modelos.Requests;
using ScreenSound.Shared.Modelos.Response;
using System.Net.Http.Json;

namespace BlazorStudy.Services
{
    public class ArtistAPI
    {
        private readonly HttpClient _httpClient;

        public ArtistAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ArtistaResponse>?> GetAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

        public async Task<ArtistaResponse?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{id}");
        }

        public async Task<HttpResponseMessage> Post(ArtistaRequest artistCreateDTO)
        {
            return await _httpClient.PostAsJsonAsync<ArtistaRequest>("artistas", artistCreateDTO);
        }
    }
}
