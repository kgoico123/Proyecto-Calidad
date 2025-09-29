using System.ComponentModel.DataAnnotations;

namespace Proyecto_Calidad.Models
{
    public class Tutor
    {
        [Key]
        public int IdTutor { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? user { get; set; }
        public string direccion { get; set; }
        public IEnumerable<Estudiante>? Estudiantes { get; set; }
        public IEnumerable<Notificacion>? Notificaciones { get; set; }
    }
}
