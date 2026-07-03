using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_context.Productos.ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult ObtenerPorId(int id)
    {
        var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
        if (producto is null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public IActionResult Crear(Producto nuevo)
    {
        _context.Productos.Add(nuevo);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevo.Id },
            nuevo);
    }

    [HttpPut("{id:int}")]
    public IActionResult Actualizar(
        int id, Producto p)
    {
        var existente = _context.Productos
            .FirstOrDefault(x => x.Id == id);
        if (existente is null)
            return NotFound();

        existente.Nombre = p.Nombre;
        existente.Precio = p.Precio;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Eliminar(int id)
    {
        var existente = _context.Productos
            .FirstOrDefault(x => x.Id == id);
        if (existente is null)
            return NotFound();

        _context.Productos.Remove(existente);
        _context.SaveChanges();
        return NoContent();
    }
}

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }

    public Producto(string nombre, decimal precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}