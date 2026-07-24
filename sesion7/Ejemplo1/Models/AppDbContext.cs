using Microsoft.EntityFrameworkCore;

namespace Ejemplo1.Models;

public class AppDbContext : DbContext
{
    public DbSet<Curso> Cursos => Set<Curso>();
	public DbSet<Estudiante> Estudiantes => Set<Estudiante>();

	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}
}
