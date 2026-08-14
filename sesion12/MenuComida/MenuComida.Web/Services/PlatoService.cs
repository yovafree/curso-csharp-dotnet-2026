using MenuComida.Web.Models;

namespace MenuComida.Web.Services;

public class PlatoService : IPlatoService
{
    private readonly HttpClient _httpClient;

    public PlatoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PlatoViewModel>> GetPlatosAsync()
    {
        var response = await _httpClient.GetAsync("api/platos");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<PlatoViewModel>>();
    }

    public async Task<PlatoViewModel> GetPlatoByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/platos/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PlatoViewModel>();
    }

    public async Task<List<PlatoViewModel>> GetPlatosByCategoriaAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/platos/categorias/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<PlatoViewModel>>();
    }

    public async Task CreatePlatoAsync(PlatoViewModel plato)
    {
        var response = await _httpClient.PostAsJsonAsync("api/platos", plato);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdatePlatoAsync(PlatoViewModel plato)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/platos/{plato.Id}", plato);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePlatoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/platos/{id}");
        response.EnsureSuccessStatusCode();
    }
}