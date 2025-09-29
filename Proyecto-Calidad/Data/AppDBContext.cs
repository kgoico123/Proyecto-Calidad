using Microsoft.EntityFrameworkCore;
using Proyecto_Calidad.Models;
using System.Reflection;


namespace Proyecto_Calidad.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Comportamiento> Comportamientos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante_Curso> Estudiantes_Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Tutor> Tutores { get; set; }

      
    }
}
