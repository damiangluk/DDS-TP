using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RankingIncidentesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;

        public RankingIncidentesController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("rankings/get-last")]
        [HttpGet]
        public string GetLastIncidente()
        {
            var impactoIncidente = _context.ImpactoIncidentes
                .OrderByDescending(t => t.FechaRanking).FirstOrDefault();

            _context.Dispose();

            object result = new
            {
                status = true,
                message = "Ranking encontrado exitosamente",
                content = new { 
                    ranking = impactoIncidente 
                }
            };

            return JsonHelper.SerializeObject(result, 2);
        }

        [Route("rankings/get-by-date")]
        [HttpGet]
        public string GetIncidentePorFecha([FromQuery]DateTime fecha)
        {
            var impactoIncidente = _context.ImpactoIncidentes.ToList()

                .OrderBy(t => Math.Abs((fecha - t.FechaRanking).TotalHours)).FirstOrDefault();

            _context.Dispose();

            object result = new
            {
                status = true,
                message = "Ranking encontrado exitosamente",
                content = new
                {
                    ranking = impactoIncidente
                }
            };

            return JsonHelper.SerializeObject(result, 2);
        }

        [Route("rankings/get-all-by-dates")]
        [HttpGet]
        public string GetIncidentesPorFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var impactoIncidente = _context.ImpactoIncidentes

                .Where(t => t.FechaRanking > fechaInicio && t.FechaRanking < fechaFin).ToList();

            _context.Dispose();

            object result = new
            {
                status = true,
                message = "Ranking encontrado exitosamente",
                content = new
                {
                    rankings = impactoIncidente
                }
            };

            return JsonHelper.SerializeObject(result, 2);
        }
    }
}