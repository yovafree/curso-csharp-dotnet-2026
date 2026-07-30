using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Estudiante
{
    public int CodEstudiante { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodCurso { get; set; }

    public virtual Curso CodCursoNavigation { get; set; } = null!;

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();
}
