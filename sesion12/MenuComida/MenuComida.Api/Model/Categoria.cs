using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MenuComida.Api.Model;
public class Categoria
{
    public int Id { get; set; }
    [Required, StringLength(60)]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    [Required, DefaultValue(1)]
    public int Estado { get; set; } // 1: Activo, 0: Inactivo
    public ICollection<Plato> Platos { get; set; } = new List<Plato>(); // Navigation property
}