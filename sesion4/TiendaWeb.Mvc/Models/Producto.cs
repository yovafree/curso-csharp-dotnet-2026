using System.ComponentModel.DataAnnotations;

namespace TiendaWeb.Mvc.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, string descripcion, decimal precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
