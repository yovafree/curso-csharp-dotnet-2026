using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Models;
namespace Ejemplo1.Controllers
{

	public class CursosController : Controller
	{
        private readonly AppDbContext _context;
		public CursosController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
            var cursos = _context.Cursos.ToList();
			return View(cursos);
		}
	}
}
