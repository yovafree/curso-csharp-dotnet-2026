using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ejemplo1.Models;

[Table("curso")]
public class Curso
{
    public Curso()
    {
        FecCreacion = DateTime.Now;
    }
    [Key]
    [Column("cod_curso")]
    public int CodCurso { get; set; }

    [Column("nombre")]
    [Required(ErrorMessage="Nombre es obligatorio"), MaxLength(45, ErrorMessage="Nombre debe ser menor a 45 caracteres")]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    [MaxLength(150, ErrorMessage="Descripcion debe ser menor a 150 caracteres")]
    public string Descripcion { get; set; } = null!;

    [Column("estado")]
    public int Estado { get; set; }

    [Column("fec_creacion")]
    public DateTime FecCreacion { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();  // 1–N implícita
}
