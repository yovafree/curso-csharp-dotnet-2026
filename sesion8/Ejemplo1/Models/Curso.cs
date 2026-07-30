using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Curso
{
    public int CodCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Estado { get; set; }

    public DateTime FecCreacion { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();
}
