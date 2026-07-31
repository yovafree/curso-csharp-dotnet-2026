using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Prestamo
{
    public int CodPrestamo { get; set; }

    public int CodLibro { get; set; }

    public int LibroCodLibro { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime FechaDevolucion { get; set; }

    public virtual Libro LibroCodLibroNavigation { get; set; } = null!;
}
