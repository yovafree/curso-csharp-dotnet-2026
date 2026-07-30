using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Ejemplo2.Models;

public class Autor
{
    [Key]
    public int CodAutor { get; set; }

    [Required]
    [StringLength(200)]
    public string Nombre { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<Libro> Libros { get; set; }
}