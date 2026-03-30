using ScreenSound.Shared.Modelos.Response;
using ScreenSound.Shared.Modelos.Requests;
using System.Net.Http.Json;
namespace BlazorStudy.Services;

public class MusicAPI
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MusicAPI> _logger;

    public MusicAPI(IHttpClientFactory factory, ILogger<MusicAPI> logger)
    {
        _httpClient = factory.CreateClient("API");
        _logger = logger;
    }

    public async Task<ICollection<MusicaResponse>?> GetAsync()
    {
        _logger.LogInformation("Getting musics...");

        try
        {
            var result = await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
            _logger.LogInformation("Musics obtained");
            return result;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            throw new ApplicationException(e.Message);
        }
    } 

    public async Task<MusicaResponse?> GetByName(string name)
    {
        if (name is not null)
        {
            return await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{name}");
        }
        return null;
    } 

    public async Task<HttpResponseMessage?> Post(MusicaRequest createMusicDTO)
    {
        if (createMusicDTO is not null)
        {
            return await _httpClient.PostAsJsonAsync<MusicaRequest>("musicas", createMusicDTO);
        }
        return null;
    }
}
