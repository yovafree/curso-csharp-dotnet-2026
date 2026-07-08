using Microsoft.EntityFrameworkCore;

namespace TiendaWeb.Mvc.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}
