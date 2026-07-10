using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcEjemplo1.Models;

namespace mvcEjemplo1.Controllers;

public class HomeController : Controller
{
    private List<string> productos = new List<string>();

    public IActionResult Index()
    {
        productos = new List<string> { "Producto 1", "Producto 2", "Producto 3", "Producto 4"};
        if (TempData.ContainsKey("Mensaje"))
        {
            ViewBag.Mensaje = TempData["Mensaje"];
        }

        ViewBag.Productos = productos;
        ViewBag.Titulo = "Listado de productos";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        TempData["Mensaje"] = "Producto guardado con éxito";
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
