using System.ComponentModel.DataAnnotations;

public class ProductoViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo")]
    public decimal Precio { get; set; }
    [Required(ErrorMessage = "La categoría es obligatoria")]
    public string Categoria { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; }
}