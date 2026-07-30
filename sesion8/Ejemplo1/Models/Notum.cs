using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Notum
{
    public int CodNota { get; set; }

    public int Nota { get; set; }

    public int CodCurso { get; set; }

    public int CodEstudiante { get; set; }

    public int Estado { get; set; }

    public virtual Curso CodCursoNavigation { get; set; } = null!;

    public virtual Estudiante CodEstudianteNavigation { get; set; } = null!;
}
