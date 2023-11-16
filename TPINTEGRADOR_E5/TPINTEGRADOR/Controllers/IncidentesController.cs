using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [Route("Incidentes/get-all")]
        [HttpPost]
        public string GetAllIncidentes([FromBody] string estado)
        {
            bool e = int.Parse(estado) == 1;
            var incidentes = DataFactory.IncidenteDao.ConsultarIncidentePorEstado(e);
            string tabla = "";
            foreach (var incidente in incidentes)
            {
                if (incidente.EstaAbierto())
                {
                    tabla += @$"<div class=""informe-incidente"">
                                <span class=""title-card"">{incidente.Informe} - {incidente.Estado}</span>
                                <div class=""actions-incidente"">
                                    <button type=""button"" class=""btn btn-info btn-100px"" onclick=""solicitarRevision({incidente.Id})"" >Solicitar revision</button>
                                    <button type=""button"" class=""btn btn-warning btn-50px"">Editar</button>
                                    <button type=""button"" class=""btn btn-danger btn-50px"" onclick=""cerrarIncidente({incidente.Id})"">Cerrar</button>
                                </div>
                            </div>";
                }
                else
                {
                    tabla += @$"<div class=""informe-incidente"">
                                <span class=""title-card"">{incidente.Informe} - {incidente.Estado}</span>
                                <div class=""actions-incidente"">
                                    <span class=""description-card"">Cerrado en: {incidente.FechaCierre.ToString()}</span>
                                </div>
                            </div>";
                }

            }
            return tabla;
        }
    }
}