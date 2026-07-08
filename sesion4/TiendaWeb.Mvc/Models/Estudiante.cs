using System.ComponentModel.DataAnnotations;

namespace TiendaWeb.Mvc.Models
{
    public class Estudiante
    {
        [Key]
        public int CodEstudiante { get; set; }

        [Required(ErrorMessage ="El campo Nombre es requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Date)]
        public DateTime FecNacimiento { get; set; }

    }
}
