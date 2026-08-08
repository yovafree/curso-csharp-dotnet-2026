using System.ComponentModel.DataAnnotations;

namespace MenuComida.Api.Model;
public class Plato
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Nombre { get; set; }

    [StringLength(400)]
    public string Descripcion { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Precio { get; set; }
    public string? ImagenUrl { get; set; }
    public int CategoriaId { get; set; } // Foreign key to Categoria
    public Categoria? Categoria { get; set; } // Navigation property
}