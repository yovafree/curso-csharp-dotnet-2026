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
    public string Nombre { get; set; } = null!;
    [Column("descripcion")]
    public string Descripcion { get; set; } = null!;
    [Column("estado")]
    public int Estado { get; set; }
    [Column("fec_creacion")]
    public DateTime FecCreacion { get; set; }
}
