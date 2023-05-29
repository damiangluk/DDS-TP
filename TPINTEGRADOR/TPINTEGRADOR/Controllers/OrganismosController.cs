using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Controllers
{
    public class OrganismosController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public OrganismosController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<string> ConsultarAPI([FromBody] List<GeoApiParam> parametros)
        {
            HttpClient httpClient = new HttpClient();

            var urls = new List<string> { "provincias", "municipios", "departamentos" };

            var data = new object[] { new { provincias = parametros[0].Param }, new { municipios = parametros[1].Param }, new { departamentos = parametros[2].Param } };

            var responses = new List<HttpResponseMessage>();

            int i = 0;
            foreach (var url in urls)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"https://apis.datos.gob.ar/georef/api/{url}"),
                    Content = new StringContent(JsonConvert.SerializeObject(data[i]), System.Text.Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
                responses.Add(response);
                i++;
            }

            var provinciasResult = new List<Localizacion>();
            var departamentosResult = new List<Localizacion>();
            var municipiosResult = new List<Localizacion>();

            GeoApiResponse? provinciasContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[0].Content.ReadAsStringAsync());
            GeoApiResponse? municipiosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[1].Content.ReadAsStringAsync());
            GeoApiResponse? departamentosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[2].Content.ReadAsStringAsync());

            provinciasResult = provinciasContent != null ? provinciasContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.provincias[0])
                .ToList() : null;

            municipiosResult = municipiosContent != null ? municipiosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.municipios[0])
                .ToList() : null;

            departamentosResult = departamentosContent != null ? departamentosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.departamentos[0])
                .ToList() : null;

            object result = new
            {
                status = true,
                content = new
                {
                    provinciasResult,
                    municipiosResult,
                    departamentosResult
                }
            };

            return JsonHelper.SerializeObject(result, 4);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}