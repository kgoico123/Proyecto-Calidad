using Proyecto_Calidad.Models;

namespace Proyecto_Calidad.ViewModels;

public class TutorComportamientoVM
{
    public Estudiante Estudiante { get; set; }
    public IEnumerable<Comportamiento> Conductas { get; set; }
}
