using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MenuComida.Web.Models;
using MenuComida.Web.Services;

namespace MenuComida.Web.Controllers;

public class HomeController : Controller
{
    private readonly IPlatoService _platoService;
    private readonly ICategoriaService _categoriaService;
    public HomeController(IPlatoService platoService, ICategoriaService categoriaService)
    {
        _platoService = platoService;
        _categoriaService = categoriaService;
    }
    public async Task<IActionResult> Index(string categoria)
    {
        Console.WriteLine("categoria: " + categoria);
        var categorias = await _categoriaService.GetCategoriasAsync();
        var platos = !string.IsNullOrEmpty(categoria) ? await _platoService.GetPlatosByCategoriaAsync(int.Parse(categoria)) : await _platoService.GetPlatosAsync();
        ViewBag.Categorias = categorias;
        return View(platos);
    }

    public async Task<IActionResult> Details(int id)
    {
        var plato = await _platoService.GetPlatoByIdAsync(id);
        if (plato == null)
        {
            return NotFound();
        }
        return View(plato);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
