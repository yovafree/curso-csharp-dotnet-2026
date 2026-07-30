using System.ComponentModel.DataAnnotations;

namespace Ejemplo2.Models;
public class Prestamo
{
    [Key]
    public int CodPrestamo { get; set; }

    [Required]
    public int CodLibro { get; set; }
    public virtual Libro Libro { get; set; }

    [Required]
    public DateTime FechaPrestamo { get; set; }

    [Required]
    public DateTime FechaDevolucion { get; set; }
}