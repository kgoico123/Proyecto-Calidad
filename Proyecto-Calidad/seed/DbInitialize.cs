using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_Calidad.Data;
using Proyecto_Calidad.Models;
using Proyecto_Calidad.shared;

namespace Proyecto_Calidad.seed;

public class DbInitialize : IDbInitialize
{
    private readonly AppDBContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public DbInitialize(AppDBContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public void Initialize()
    {
        try
        {
            //if(_context.Database.GetPendingMigrations().Count() > 0)
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }
        }
        catch (Exception)
        {
            throw;
        }

        // Crear roles si no existen
        if (!_context.Roles.Any())
        {
            _roleManager.CreateAsync(new IdentityRole(VCG.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(VCG.Role_Estudiante)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(VCG.Role_Tutor)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(VCG.Role_Docente)).GetAwaiter().GetResult();
        }

        // Crear usuarios si no existen (verificamos por DNI específico)
        var adminExists = _userManager.Users.Any(u => u.Dni == "76543111");
        if (!adminExists)
        {
            var admin = new ApplicationUser
            {
                Email = "admin@dev.cs",
                UserName = "admin@dev.cs",
                PhoneNumber = "123456789",
                Dni = "76543111",
            };

            var estudiante = new ApplicationUser
            {
                Email = "estudiante@dev.cs",
                UserName = "estudiante@dev.cs",
                PhoneNumber = "123456789",
                Dni = "76543331",
            };

            var tutor = new ApplicationUser
            {
                Email = "tutor@dev.cs",
                UserName = "tutor@dev.cs",
                PhoneNumber = "123456789",
                Dni = "76544441",
            };

            var docente = new ApplicationUser
            {
                Email = "docente@dev.cs",
                UserName = "docente@dev.cs",
                PhoneNumber = "123456789",
                Dni = "76543221",
            };

            _userManager.CreateAsync(admin, "Admin123*").GetAwaiter().GetResult();
            _userManager.CreateAsync(estudiante, "Estudiante123*").GetAwaiter().GetResult();
            _userManager.CreateAsync(tutor, "Tutor123*").GetAwaiter().GetResult();
            _userManager.CreateAsync(docente, "Docente123*").GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(admin, VCG.Role_Admin).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(tutor, VCG.Role_Tutor).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(estudiante, VCG.Role_Estudiante).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(docente, VCG.Role_Docente).GetAwaiter().GetResult();

            if (!_context.Tutores.Any() && !_context.Estudiantes.Any() && !_context.Docentes.Any())
            {
                var nuevoTutor = new Tutor { UserId = tutor.Id, direccion = "Calle Falsa 123" };
                _context.Tutores.Add(nuevoTutor);
                _context.SaveChanges();

                var nuevoEstudiante = new Estudiante { UserId = estudiante.Id, TutorId = nuevoTutor.IdTutor, Grado = Grados.Primero };
                _context.Estudiantes.Add(nuevoEstudiante);

                var nuevoDocente = new Docente { UserId = docente.Id };
                _context.Docentes.Add(nuevoDocente);

                _context.SaveChanges();
            }
        }
    }
}
