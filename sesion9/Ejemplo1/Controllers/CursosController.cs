using Ejemplo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Ejemplo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CursosController: ControllerBase
    {
        private readonly ILogger<CursosController> _logger;
        private readonly CursoDbContext _context;
        public CursosController(ILogger<CursosController> logger, CursoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCursos()
        {
            var cursos = _context.Cursos.ToList();
            return Ok(cursos);
        }
    }
}