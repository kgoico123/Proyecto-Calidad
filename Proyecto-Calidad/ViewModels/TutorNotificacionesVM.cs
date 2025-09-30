using Proyecto_Calidad.Models;

namespace Proyecto_Calidad.ViewModels;

public class TutorNotificacionesVM
{
    public IEnumerable<Notificacion> Notificaciones { get; set; }
    public Estudiante Estudiante { get; set; }
}
