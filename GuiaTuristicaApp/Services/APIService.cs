using System.Net.Http.Headers;
using System.Text.Json;

namespace GuiaTuristicaApp.Services;

public class APIService : IAPIService
{
    private readonly HttpClient _client;

    public APIService(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://guiaturistica-fqecgpc9gac2hdfq.canadacentral-01.azurewebsites.net/api/");
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        return default;
    }
}