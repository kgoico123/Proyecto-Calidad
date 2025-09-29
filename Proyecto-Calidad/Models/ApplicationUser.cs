using System.ComponentModel.DataAnnotations;

namespace Proyecto_Calidad.Models
{
    public class ApplicationUser
    {
        [Key]
        public string? Dni { get; set; }
        public string? Apellido { get; set; }
    }
}
