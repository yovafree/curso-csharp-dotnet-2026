using System.ComponentModel.DataAnnotations;

namespace MenuComida.Web.Models
{
    public class PlatoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10000")]
        public decimal Precio { get; set; }
        public string? ImagenUrl { get; set; }
        public int Estado {get; set; }
        [Required(ErrorMessage = "Selecciona una categoría")]
        public int CategoriaId { get; set; }
        public CategoriaViewModel? Categoria { get; set; }
    }
}