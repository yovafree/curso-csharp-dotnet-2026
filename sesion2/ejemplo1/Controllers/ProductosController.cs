using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ILogger<ProductosController> _logger;

    public ProductosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Producto> GetProductos()
    {
        _logger.LogInformation("Obteniendo la lista de productos");
        _logger.LogWarning("Este es un mensaje de advertencia");
        _logger.LogError("Este es un mensaje de error");

        // Lógica para obtener la lista de productos
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto A", Precio = 10.99m },
            new Producto { Id = 2, Nombre = "Producto B", Precio = 15.49m },
            new Producto { Id = 3, Nombre = "Producto C", Precio = 7.99m }
        };
    }

    [HttpGet("{id}")]
    public Producto GetProducto(int id)
    {
        // Lógica para obtener un producto por su ID
        var productos = GetProductos();
        return productos.FirstOrDefault(p => p.Id == id);
    }

    [HttpPost]
    public void AgregarProducto(Producto producto)
    {
        // Lógica para agregar un nuevo producto
        // Aquí podrías agregar el producto a una base de datos o lista
    }

    [HttpPut("{id}")]
    public void ActualizarProducto(int id, Producto productoActualizado)
    {
        // Lógica para actualizar un producto existente
        // Aquí podrías buscar el producto por su ID y actualizar sus propiedades
    }

    [HttpDelete("{id}")]
    public void EliminarProducto(int id)
    {
        // Lógica para eliminar un producto por su ID
        // Aquí podrías buscar el producto por su ID y eliminarlo de la base de datos o lista
    }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}