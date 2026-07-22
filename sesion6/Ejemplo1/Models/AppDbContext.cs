using Microsoft.EntityFrameworkCore;

namespace Ejemplo1.Models;

public class AppDbContext : DbContext
{
    public DbSet<Curso> Cursos => Set<Curso>();
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}
}
