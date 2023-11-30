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
            return AbrirIncidente();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AbrirIncidente()
        {
            ViewBag.Servicios = DataFactory.ServicioDao.GetAllFromDropdown();
            ViewBag.Localizaciones = DataFactory.LocalizacionDao.GetAllFromDropdown();

            return View("AbrirIncidente");
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
            List<Incidente> incidentes;
            try
            {
                bool e = int.Parse(estado) == 1;
                incidentes = DataFactory.IncidenteDao.ConsultarIncidentePorEstado(e);
            }
            catch(Exception)
            {
                incidentes = DataFactory.IncidenteDao.GetAll();
            }

            string tabla = "";
            foreach (var incidente in incidentes)
            {
                if (incidente.EstaAbierto())
                {
                    tabla += @$"<div class=""informe-incidente"">
                                <div class=""title-card-container"">
                                    <span class=""title-card"">{incidente.Servicio.Nombre}</span>
                                    <span class=""subtitle-card"">{incidente.Informe} - {incidente.Estado}</span>
                                </div>
                                <div class=""actions-incidente"">
                                    <button type=""button"" class=""btn btn-info btn-100px"" onclick=""solicitarRevision('{incidente.Servicio.Nombre}','{incidente.Informe}', {incidente.Id})"" >Solicitar revision</button>
                                    <button type=""button"" class=""btn btn-warning btn-50px"">Editar</button>
                                    <button type=""button"" class=""btn btn-danger btn-50px"" onclick=""cerrarIncidente({incidente.Id})"">Cerrar</button>
                                </div>
                            </div>";
                }
                else
                {
                    tabla += @$"<div class=""informe-incidente"">
                                <div class=""title-card-container"">
                                    <span class=""title-card"">{incidente.Servicio.Nombre}</span>
                                    <span class=""subtitle-card"">{incidente.Informe} - {incidente.Estado}</span>
                                </div>
                                <div class=""actions-incidente"">
                                    <span class=""description-card"">Cerrado en: {incidente.FechaCierre.ToString()}</span>
                                </div>
                            </div>";
                }

            }
            if (string.IsNullOrEmpty(tabla)) tabla = "<h4>No se encontraron incidentes</h4>";
            return tabla;
        }

        [AllowAnonymous]
        [Route("Incidentes/close")]
        [HttpPost]
        public string CerrarIncidente([FromBody] int id)
        {
            string result = "Incidente cerrado exitosamente";
            try
            {
                var incidente = DataFactory.IncidenteDao.GetById(id);
                incidente.FechaCierre = DateTime.Now;
                DataFactory.IncidenteDao.Update(incidente);  
            }
            catch (Exception)
            {
                result = "Ocurrio un error al cerrar el incidente";
            }
            return result;
        }

        [AllowAnonymous]
        [Route("Incidentes/solicitar-revision")]
        [HttpPost]
        public void SolicitarRevision([FromBody] int id)
        {
            var incidente = DataFactory.IncidenteDao.GetById(id);
            var personas = incidente.Comunidades.SelectMany(c => c.Miembros).Select(m => m.Persona).ToList();
            foreach (var persona in personas) {
                var obj = DataFactory.PersonaDao.GetById(persona.Id);
                var notificacion = new Notificacion(DateTime.Now, obj, "Te solicitaron que revises el incidete: " + incidente.Informe + " del servicio: " + incidente.Servicio.Nombre);
                DataFactory.NotificacionDao.Insert(notificacion);
            }
        }
    }
}