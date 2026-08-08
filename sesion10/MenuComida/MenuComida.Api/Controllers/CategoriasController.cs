using MenuComida.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace MenuComida.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly MenuDbContext _context;

        public CategoriasController(MenuDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult CreateCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}