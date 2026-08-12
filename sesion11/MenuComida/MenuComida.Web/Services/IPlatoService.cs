using MenuComida.Web.Models;

namespace MenuComida.Web.Services
{
    public interface IPlatoService
    {
        Task<List<PlatoViewModel>> GetPlatosAsync();
        Task<PlatoViewModel> GetPlatoByIdAsync(int id);
        Task<List<PlatoViewModel>> GetPlatosByCategoriaAsync(int id);
        Task CreatePlatoAsync(PlatoViewModel plato);
        Task UpdatePlatoAsync(PlatoViewModel plato);
        Task DeletePlatoAsync(int id);
    }
}