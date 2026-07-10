using Microsoft.AspNetCore.Mvc;

public class ProductosController : Controller
{
    public ProductosController()
    {
    }

    public IActionResult Index(string search, string sort, int page = 1)
    {
        Console.WriteLine($"El valor de search es: {search}");
        Console.WriteLine($"El valor de sort es: {sort}");
        Console.WriteLine($"El valor de page es: {page}");
        return View();
    }

    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Crear(ProductoViewModel producto)
    {
        Console.WriteLine($"El valor de Id es: {producto.Id}");
        Console.WriteLine($"El valor de Nombre es: {producto.Nombre}");
        Console.WriteLine($"El valor de Precio es: {producto.Precio}");
        Console.WriteLine($"El valor de Categoria es: {producto.Categoria}");
        Console.WriteLine($"El valor de Descripcion es: {producto.Descripcion}");
        return View(producto);
    }
}