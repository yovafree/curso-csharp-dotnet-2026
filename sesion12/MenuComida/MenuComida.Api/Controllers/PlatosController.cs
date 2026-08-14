using Microsoft.AspNetCore.Mvc;
using MenuComida.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace MenuComida.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly MenuDbContext _context;

        public PlatosController(MenuDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPlatos()
        {
            var platos = _context.Platos.Select(p => new 
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                CategoriaId = p.CategoriaId,
                Categoria = new 
                {
                    Id = p.Categoria.Id,
                    Nombre = p.Categoria.Nombre,
                    Descripcion = p.Categoria.Descripcion
                }
            }).ToList();
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlato(int id)
        {
            var plato = _context.Platos.Include(p => p.Categoria).FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            var temp = new 
            {
                Id = plato.Id,
                Nombre = plato.Nombre,
                Descripcion = plato.Descripcion,
                Precio = plato.Precio,
                ImagenUrl = plato.ImagenUrl,
                CategoriaId = plato.CategoriaId,
                Categoria = new 
                {
                    Id = plato.Categoria.Id,
                    Nombre = plato.Categoria.Nombre,
                    Descripcion = plato.Categoria.Descripcion
                }
            };
            return Ok(temp);
        }

        [HttpGet("categorias/{id}")]
        public IActionResult GetPlatosCategorias(int id)
        {
            var platos = _context.Platos.Where(p => p.CategoriaId == id).Select(p => new 
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                ImagenUrl = p.ImagenUrl,
                CategoriaId = p.CategoriaId,
                Categoria = new 
                {
                    Id = p.Categoria.Id,
                    Nombre = p.Categoria.Nombre,
                    Descripcion = p.Categoria.Descripcion
                }
            }).ToList();
            
            return Ok(platos);
        }

        [HttpPost]
        public IActionResult CreatePlato(Plato plato)
        {
            _context.Platos.Add(plato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPlatos), new { id = plato.Id }, plato);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlato(int id, Plato plato)
        {
            if (id != plato.Id)
            {
                return BadRequest();
            }

            _context.Platos.Update(plato);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlato(int id)
        {
            var plato = _context.Platos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            _context.Platos.Remove(plato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}