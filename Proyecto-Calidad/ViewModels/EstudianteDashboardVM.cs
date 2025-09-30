using System.Collections.Generic;

namespace Proyecto_Calidad.ViewModels
{
    public class EstudianteDashboardVM
    {
        
        public string NombreEstudiante { get; set; }
        public List<CursoEstudianteVM> Cursos { get; set; } = new List<CursoEstudianteVM>();
    }
}