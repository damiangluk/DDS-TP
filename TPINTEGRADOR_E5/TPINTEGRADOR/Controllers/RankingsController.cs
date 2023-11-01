using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.daos.auxClasses;
using TPINTEGRADOR.Models.entities.ServicioRanking;

namespace TPINTEGRADOR.Controllers
{
    public class RankingsController : Controller
    {
        private readonly ILogger<RankingsController> _logger;

        public RankingsController(ILogger<RankingsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(DateTime? fechaInicio = null, DateTime? fechaFin = null, TipoRanking? tipo = null)
        {
            ViewBag.FechaDesde = fechaInicio.HasValue ? fechaInicio.Value : DateTime.Now.AddDays(-7);
            ViewBag.FechaHasta = fechaFin.HasValue ? fechaFin.Value : DateTime.Now;
            List<Ranking> rankings = DataFactory.RankingDao.GetAllByDates(ViewBag.FechaDesde, ViewBag.FechaHasta, tipo);

            ViewBag.Rankings = rankings
                .Select(t => new
                {
                    Fecha = t.Fecha,
                    Ranking = t.DeserializarRanking().Select(x => new
                    {
                        Entidad = x.Item2,
                        Valor = x.Item3
                    }).ToList(),
                    TipoRanking = t.TipoRanking.GetTipo()
                });

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}