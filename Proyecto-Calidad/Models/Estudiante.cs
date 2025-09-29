using System.ComponentModel.DataAnnotations;

namespace Proyecto_Calidad.Models
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? user { get; set; }
        public string Grado { get; set; }
        public IEnumerable<Estudiante_Curso> Estudiante_Cursos { get; set; }
    }
}
