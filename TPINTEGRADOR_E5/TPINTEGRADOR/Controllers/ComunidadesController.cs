using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [AllowAnonymous]
        [Route("Comunidades/get-all")]
        [HttpPost]
        public string GetAllComunidades()
        {
            var persona = SessionManager.GetPersona();
            var participaciones = DataFactory.ParticipacionDao.GetAllByPerson(persona);
            List<Rol> roles = RolExtensions.GetAllRoles();
            string tabla = "";
            foreach (var participacion in participaciones)
            {
                tabla += @$"<div class=""informe-incidente"" style=""width:800px;"">
                    <span class=""title-card"">{participacion.Comunidad.Nombre}</span>
                    <div class=""actions-incidente"" style=""display: flex;"">
                            <select class=""form-select"" id=""select-form"" style=""margin-right: 5px;"" aria-label=""Disabled select example"" onchange=""changeRol()"" name=""Rol"">";

                foreach (var rol in roles)
                {
                    if ((int)rol == (int)participacion.Rol)
                    {
                        tabla += $@"<option selected value = ""{((int)rol).ToString()}"" > {rol.GetTipo()} </option>";
                    }
                    else
                    {
                        tabla += $@"<option value = ""{((int)rol).ToString()}"" > {rol.GetTipo()} </option>";
                    }
                }
                tabla += @$"</select>
                    <input type=""hidden"" name=""Participacion"" value=""{participacion.Id}"" />
                    <button type=""button"" class=""btn btn-warning btn-50px"">Mas</button>
                    </div>
                </div>";
            }
            if (!participaciones.Any()) tabla = "<h4>No se encontraron comunidades</h4>";
            return tabla;
        }

        [AllowAnonymous]
        [Route("Comunidades/cambiar-rol")]
        [HttpPost]
        public string CambiarRolLiviano([FromBody] CambiarRolRequest data)
        {
            int rol = data.Rol;
            int participacion = data.Participacion;

            Participacion part = DataFactory.ParticipacionDao.GetById(participacion);
            part.Rol = (Rol)Enum.ToObject(typeof(Rol), rol);
            DataFactory.ParticipacionDao.Update(part);
            return "Listo";
        }

        public class CambiarRolRequest
        {
            public int Rol { get; set; }
            public int Participacion { get; set; }
        }
    }
}