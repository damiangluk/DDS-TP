using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Controllers
{
    public class ComunidadesController : Controller
    {
        private readonly ILogger<ComunidadesController> _logger;

        public ComunidadesController(ILogger<ComunidadesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var persona = SessionManager.GetPersona();
            ViewBag.Participaciones = DataFactory.ParticipacionDao.GetAllByPerson(persona).Select(p => new
            {
                Id = p.Id,
                Rol = (int)p.Rol,
                Comunidad = p.Comunidad.Nombre
            });
            ViewBag.Roles = RolExtensions.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CambiarRol(int Rol, int Participacion)
        {
            Participacion part = DataFactory.ParticipacionDao.GetById(Participacion);
            part.Rol = (Rol)Enum.ToObject(typeof(Rol), Rol);
            DataFactory.ParticipacionDao.Update(part);
            return RedirectToAction("Index"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}