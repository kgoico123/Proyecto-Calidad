using Proyecto_Calidad.Models;

namespace Proyecto_Calidad.ViewModels;

public class DocenteDashboardVM
{
    public Docente docente { get; set; }
    public Curso curso { get; set; }
    public int CantidadAlumnos { get; set; }
}
