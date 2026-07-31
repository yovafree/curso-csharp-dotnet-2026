using System;
using System.Collections.Generic;

namespace Ejemplo1.Models;

public partial class Autore
{
    public int CodAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
