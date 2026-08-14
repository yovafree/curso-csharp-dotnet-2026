using MenuComida.Web.Models;
using System.Net.Http.Json;

namespace MenuComida.Web.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoriaViewModel>> GetCategoriasAsync()
        {
            var response = await _httpClient.GetAsync("api/categorias");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoriaViewModel>>();
        }

        public async Task<CategoriaViewModel> GetCategoriaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/categorias/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoriaViewModel>();
        }

        public async Task CreateCategoriaAsync(CategoriaViewModel categoria)
        {
            var response = await _httpClient.PostAsJsonAsync("api/categorias", categoria);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCategoriaAsync(CategoriaViewModel categoria)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/categorias/{categoria.Id}", categoria);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/categorias/{id}");
            try
            {
                
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var mensaje = await response.Content.ReadAsStringAsync();

                throw new Exception($"{mensaje}");
                
            }
            // var response = await _httpClient.DeleteAsync($"api/categorias/{id}");
            // response.EnsureSuccessStatusCode();

        }
    }
}