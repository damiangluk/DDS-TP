using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                    Id = t.Id,
                    Fecha = t.Fecha,
                    Ranking = t.DeserializarRanking().Select(x => new
                    {
                        Entidad = x.nombreEnt,
                        Valor = x.impacto
                    }).ToList(),
                    TipoRanking = t.TipoRanking.GetTipo()
                });
            ViewBag.TiposRanking = TipoRankingExtensions.GetAll();
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [Route("Rankings/get-all")]
        [HttpPost]
        public string GetAllRankings([FromBody] RankingsRequest request)
        {
            if (request.FechaInicio == request.FechaFin)
                request.FechaInicio.Value.AddDays(-7);

            var FechaDesde = request.FechaInicio.Value;
            var FechaHasta = request.FechaFin.Value;
            List<Ranking> rankings = DataFactory.RankingDao.GetAllByDates(FechaDesde, FechaHasta, request.TipoRanking);

            var table = string.Empty;
            
            foreach (var item in rankings)
            {
                table += $@"
                    <div class=""card"">
                        <div class=""card-header"" id=""heading {item.Id}"">
                            <h5 class=""mb-0"">
                                <button class=""btn btn-link"" data-toggle=""collapse"" data-target=""#{item.Id}"" aria-expanded=""true"" aria-controls=""{item.Id}"">
                                    {item.TipoRanking.ToString()} - {item.Fecha.ToString()})
                                </button>
                            </h5>
                        </div>

                        <div id=""{item.Id}"" class=""collapse"" aria-labelledby=""heading {item.Id}"" data-parent=""#accordion"">
                            <div class=""card-body"">
                                <table class=""table table-dark large-table"">
                                    <thead>
                                        <tr>
                                            <th scope=""col"">Posicion</th>
                                            <th scope=""col"">Entidad</th>
                                            <th scope=""col"">Valor</th>
                                        </tr>
                                    </thead>
                                    <tbody>";
                
                var itemDeserialized = item.DeserializarRanking();
                for (var i = 0; i < itemDeserialized.Count; i++)
                {
                    table += $@"<tr>
                                    <th scope=""row""> {(i + 1).ToString()}</th>
                                    <td>{itemDeserialized[i].nombreEnt}</td>
                                    <td>{itemDeserialized[i].impacto}</td>
                                </tr>";
                }

                table += $@"</tbody></table></div></div></div>";
            };

            if (!rankings.Any()) table += "<h4>No se encontraron resultados</h4>";

            return table;
        }


        [AllowAnonymous]
        [Route("Rankings/charge-select")]
        [HttpPost]
        public string ChargeSelect()
        {
            var tiposDeRanking = TipoRankingExtensions.GetAllTiposRankings();

            var select = $@"<select class=""form-select"" aria-label=""Disabled select example"" name=""tipoRanking"">";

            foreach (var type in tiposDeRanking)
            {
                select += $@"<option value=""{((int)type).ToString()}"">{type.GetTipo()}</option>";
            }

            select += "</select>";

            return select;
        }

        public class RankingsRequest
        {
            public DateTime? FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
            public TipoRanking? TipoRanking { get; set; }
        }
    }
}