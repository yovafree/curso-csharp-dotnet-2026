using Microsoft.EntityFrameworkCore;

namespace MenuComida.Api.Model;

public class MenuDbContext : DbContext
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Plato> Platos => Set<Plato>();

    public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Removes the automatic database-level cascade delete behavior
        configurationBuilder.Conventions.Remove(typeof(Microsoft.EntityFrameworkCore.Metadata.Conventions.CascadeDeleteConvention));
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Grab all foreign keys across all entities
        var foreignKeys = mb.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade);

        // Set their delete behavior to Restrict (or NoAction)
        foreach (var fk in foreignKeys)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

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