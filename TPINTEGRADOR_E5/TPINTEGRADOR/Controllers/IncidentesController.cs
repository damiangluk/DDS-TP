using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Controllers
{
    public class IncidentesController : Controller
    {
        private readonly ILogger<IncidentesController> _logger;

        public IncidentesController(ILogger<IncidentesController> logger)
        {
            _logger = logger;
        }

        public IActionResult AgregarIncidente(int servicio, string informe, int localizacion) {
            var SuperServicio = DataFactory.ServicioDao.GetById(servicio);
            var Localizacion = DataFactory.LocalizacionDao.GetById(localizacion);
            Incidente incidente = new Incidente(SuperServicio, Localizacion, informe, "Incidente recien creado");
            DataFactory.IncidenteDao.Insert(incidente);
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AbrirIncidente()
        {
            ViewBag.Servicios = DataFactory.ServicioDao.GetAllFromDropdown();
            ViewBag.Localizaciones = DataFactory.LocalizacionDao.GetAllFromDropdown();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}