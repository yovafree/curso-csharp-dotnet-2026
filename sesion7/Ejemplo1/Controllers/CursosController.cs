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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Curso curso)
		{
			curso.FecCreacion = DateTime.Now;
			if (ModelState.IsValid)
			{
				_context.Cursos.Add(curso);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(curso);
		}

		public IActionResult Details(int id)
		{
			var curso = _context.Cursos.FirstOrDefault(c => c.CodCurso == id);
			if (curso == null)
			{
				return NotFound();
			}
			return View(curso);
		}

		public IActionResult Edit(int id)
		{
			var curso = _context.Cursos.FirstOrDefault(c => c.CodCurso == id);
			if (curso == null)
			{
				return NotFound();
			}
			return View(curso);
		}

		[HttpPost]
		public IActionResult Edit(Curso curso)
		{
			if (ModelState.IsValid)
			{
				_context.Cursos.Update(curso);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(curso);
		}

		public IActionResult Delete(int id)
		{
			var curso = _context.Cursos.FirstOrDefault(c => c.CodCurso == id);
			if (curso == null)
			{
				return NotFound();
			}
			return View(curso);
		}
		
		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			var curso = _context.Cursos.FirstOrDefault(c => c.CodCurso == id);
			if (curso == null)
			{
				return NotFound();
			}
			_context.Cursos.Remove(curso);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
