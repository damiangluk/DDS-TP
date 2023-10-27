using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Comunidades = DataFactory.ComunidadDao.GetAllByUser(SessionManager.GetPersona());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}