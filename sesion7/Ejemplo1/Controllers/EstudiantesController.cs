using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Models;
using Microsoft.EntityFrameworkCore;
namespace Ejemplo1.Controllers
{
	public class EstudiantesController : Controller
	{
        private readonly AppDbContext _context;
		public EstudiantesController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
            var estudiantes = _context.Estudiantes.Include(e => e.Curso).ToList();
			return View(estudiantes);
		}
	}
}
