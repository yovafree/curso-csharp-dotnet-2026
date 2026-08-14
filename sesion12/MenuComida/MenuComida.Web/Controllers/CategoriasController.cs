namespace MenuComida.Web.Controllers;

using MenuComida.Web.Models;
using MenuComida.Web.Services;
using Microsoft.AspNetCore.Mvc;

public class CategoriasController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    public async Task<IActionResult> Index()
    {
        var categorias = await _categoriaService.GetCategoriasAsync();
        return View(categorias);
    }

    public async Task<IActionResult> Details(int id)
    {
        var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaViewModel categoria)
    {
        if (ModelState.IsValid)
        {
            await _categoriaService.CreateCategoriaAsync(categoria);
            return RedirectToAction(nameof(Index));
        }
        return View(categoria);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CategoriaViewModel categoria)
    {
        if (id != categoria.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _categoriaService.UpdateCategoriaAsync(categoria);
            return RedirectToAction(nameof(Index));
        }
        return View(categoria);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }

        ViewBag.Error = TempData["Error"];
        return View(categoria);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _categoriaService.DeleteCategoriaAsync(id);
        }
        catch (Exception ex)
        {
            // Manejar la excepción según sea necesario, por ejemplo, mostrar un mensaje de error
            ModelState.AddModelError(string.Empty, "Error al eliminar la categoría: " + ex.Message);

            TempData["Error"] = "" + ex.Message;
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            return RedirectToAction(nameof(Delete), new { id = id });
        }
        // await _categoriaService.DeleteCategoriaAsync(id);
        return RedirectToAction(nameof(Index));
    }
}