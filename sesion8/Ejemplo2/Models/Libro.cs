using System.ComponentModel.DataAnnotations;

namespace Ejemplo2.Models;

public class Libro
{
    [Key]
    public int CodLibro { get; set; }

    [Required]
    [StringLength(200)]
    public string Titulo { get; set; }
    [Required]
    public int AnioPublicacion { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public int CodAutor { get; set; }
    public virtual Autor Autor { get; set; }
}