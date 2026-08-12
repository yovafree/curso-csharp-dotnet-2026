namespace MenuComida.Web.Controllers;

using MenuComida.Web.Models;
using MenuComida.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class PlatosController : Controller
{
    private readonly IPlatoService _platoService;
    private readonly ICategoriaService _categoriaService;

    public PlatosController(IPlatoService platoService, ICategoriaService categoriaService)
    {
        _platoService = platoService;
        _categoriaService = categoriaService;
    }

    public async Task<IActionResult> Index()
    {
        var platos = await _platoService.GetPlatosAsync();
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

    public async Task<IActionResult> Create()
    {
        var categorias = await _categoriaService.GetCategoriasAsync();

        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PlatoViewModel plato)
    {
        if (ModelState.IsValid)
        {
            await _platoService.CreatePlatoAsync(plato);
            return RedirectToAction(nameof(Index));
        }
        var categorias = await _categoriaService.GetCategoriasAsync();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
        return View(plato);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var plato = await _platoService.GetPlatoByIdAsync(id);
        var categorias = await _categoriaService.GetCategoriasAsync();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");

        if (plato == null)
        {
            return NotFound();
        }
        return View(plato);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, PlatoViewModel plato)
    {
        if (id != plato.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _platoService.UpdatePlatoAsync(plato);
            return RedirectToAction(nameof(Index));
        }

        var categorias = await _categoriaService.GetCategoriasAsync();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
        return View(plato);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var plato = await _platoService.GetPlatoByIdAsync(id);
        if (plato == null)
        {
            return NotFound();
        }
        return View(plato);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _platoService.DeletePlatoAsync(id);
        return RedirectToAction(nameof(Index));
    }
}