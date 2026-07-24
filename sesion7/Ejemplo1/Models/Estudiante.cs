using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejemplo1.Models;

[Table("estudiante")]
public class Estudiante
{
    [Key]
    [Column("cod_estudiante")]
	public int CodEstudiante { get; set; }

    [Column("nombre")]
	public string? Nombre { get; set; }

    [Column("cod_curso")]
    [ForeignKey("Curso")]
    public int CodCurso { get; set; }
    public virtual Curso Curso { get; set; } = null!;  // N–1 implícita
}
