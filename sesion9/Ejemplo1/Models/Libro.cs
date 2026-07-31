using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Libro
{
    public int CodLibro { get; set; }

    public string Titulo { get; set; } = null!;

    public int AnioPublicacion { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public int CodAutor { get; set; }

    public int AutorCodAutor { get; set; }

    public virtual Autore AutorCodAutorNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
