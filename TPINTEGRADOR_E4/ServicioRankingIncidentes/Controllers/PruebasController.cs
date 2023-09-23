using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PruebasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;

        public PruebasController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("test")]
        [HttpGet]
        public string GetDePrueba()
        {
            object result = new
            {
                status = true,
                message = "LLEGO",
                content = "PRUEBA EXITOSA"
            };

            return JsonHelper.SerializeObject(result, 1);
        }

        [Route("rankings/get-last")]
        [HttpPost]
        public string GetLastIncidente()
        {
            // validar propiedades del usuario

            var impactoIncidente = _context.ImpactoIncidentes
                .OrderByDescending(t => t.FechaRanking).FirstOrDefault();

            _context.Dispose();

            object result = new
            {
                status = true,
                message = "Persona guardada correctamente",
                content = new { 
                    ranking = impactoIncidente 
                }
            };

            return JsonHelper.SerializeObject(result, 2);
        }
    }
}