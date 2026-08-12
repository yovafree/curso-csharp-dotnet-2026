using Microsoft.AspNetCore.Mvc;
using MenuComida.Api.Model;

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
            var platos = _context.Platos.ToList();
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlato(int id)
        {
            var plato = _context.Platos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            return Ok(plato);
        }

        [HttpGet("categorias/{id}")]
        public IActionResult GetPlatosCategorias(int id)
        {
            var platos = _context.Platos.Where(p => p.CategoriaId == id).ToList();
            if (platos == null)
            {
                return NotFound();
            }
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