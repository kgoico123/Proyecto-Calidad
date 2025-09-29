using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Calidad.ViewModels;

namespace Proyecto_Calidad.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: /Administrador/Register
        public IActionResult Register()
        {
            NewRegisterTypeUserVM dataResponse = new NewRegisterTypeUserVM
            {
                cursos = _context.Cursos.ToList(),
                tutores = _context.Tutores.Include(t => t.user).ToList()
            };
            return View(dataResponse);
        }


    }
}
