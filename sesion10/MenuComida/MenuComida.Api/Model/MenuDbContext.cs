using Microsoft.EntityFrameworkCore;

namespace MenuComida.Api.Model;

public class MenuDbContext : DbContext
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Plato> Platos => Set<Plato>();

    public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Plato>()
        .HasOne(p => p.Categoria)
        .WithMany(c => c.Platos)
        .HasForeignKey(p => p.CategoriaId);

        mb.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Entradas", Descripcion = "Deliciosas entradas para abrir el apetito", Estado = 1 },
            new Categoria { Id = 2, Nombre = "Platos principales", Descripcion = "Platos principales deliciosos", Estado = 1 },
            new Categoria { Id = 3, Nombre = "Postres", Descripcion = "Dulces y postres", Estado = 1 },
            new Categoria { Id = 4, Nombre = "Bebidas", Descripcion = "Bebidas refrescantes", Estado = 1 }
        );
    }
}