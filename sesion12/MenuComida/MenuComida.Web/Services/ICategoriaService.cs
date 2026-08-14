using MenuComida.Web.Models;

namespace MenuComida.Web.Services
{
    public interface ICategoriaService
    {
        Task<List<CategoriaViewModel>> GetCategoriasAsync();
        Task<CategoriaViewModel> GetCategoriaByIdAsync(int id);
        Task CreateCategoriaAsync(CategoriaViewModel categoria);
        Task UpdateCategoriaAsync(CategoriaViewModel categoria);
        Task DeleteCategoriaAsync(int id);
    }
}