using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
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
        public async Task<string> ValidarArchivo(IFormFile archivoCSV)
        {
            string[] rows;
            using (var reader = new StreamReader(archivoCSV.OpenReadStream(), Encoding.Latin1))
            {
                if (!Path.GetExtension(archivoCSV.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    object resultError = new
                    {
                        status = true,
                        validation = false,
                        message = "El archivo ingresado no es un CSV"
                    };

                    return JsonHelper.SerializeObject(resultError, 4);
                }

                string contents = await reader.ReadToEndAsync();
                rows = contents.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);

                if (rows.Length < 2 || string.IsNullOrEmpty(rows[1]))
                {
                    object resultError = new
                    {
                        status = true,
                        validation = false,
                        message = "El archivo ingresado es invalido"
                    };

                    return JsonHelper.SerializeObject(resultError, 4);
                }
            }

            List<object> rowsValidated = new List<object>();
            var rowsError = "";
            Tuple<List<Localizacion>, List<Localizacion>, List<Localizacion>> results;

            try
            {
                List<GeoApiParam> parametros = CargarParametros(rows);
                results = await ConsultarAPI(parametros);

                for(int i = 1; i < (rows.Length - 1); i++)
                {
                    string[] columns = rows[i].Split(',');
                    if (ValidarFila(columns, results))
                        rowsValidated.Add(rows[i]);
                    else
                        rowsError += (columns[4] + ",");
                }

            } catch(Exception e) 
            {
                object resultError = new
                {
                    status = true,
                    validation = false,
                    message = "Ocurrio un error: " + e.Message
                };

                return JsonHelper.SerializeObject(resultError, 4);
            }

            if (!string.IsNullOrEmpty(rowsError))
            {
                rowsError = "No se encontraron las siguiente localizaciones: " + rowsError.Substring(0, rowsError.Length - 1);
            }

            object result = new
            {
                status = true,
                validation = true,
                content = new { 
                    rowsError,
                    rowsValidated,
                    provinciasResult = results.Item1,
                    municipiosResult = results.Item2,
                    departamentosResult = results.Item3
                }
            };

            return JsonHelper.SerializeObject(result, 4);
        }

        private List<GeoApiParam> CargarParametros(string[] rows) {
            var geoApiParams = new List<GeoApiParam>();

            var provincias = new GeoApiParam();
            var municipios = new GeoApiParam();
            var departamentos = new GeoApiParam();

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columnsRow = rows[i].Split(',');

                if (columnsRow[0] == string.Empty) break;
                columnsRow[4] = columnsRow[4].Replace("\r$", "");

                if (columnsRow[3] == "DEPARTAMENTO" && !departamentos.Param.Any(d => d.nombre == columnsRow[4]))
                {
                    departamentos.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
                else if (columnsRow[3] == "MUNICIPIO" && !municipios.Param.Any(m => m.nombre == columnsRow[4]))
                {
                    municipios.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
                else if (columnsRow[3] == "PROVINCIA" && !provincias.Param.Any(p => p.nombre == columnsRow[4]))
                {
                    provincias.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
            }
            geoApiParams.Add(provincias);
            geoApiParams.Add(municipios);
            geoApiParams.Add(departamentos);

            return geoApiParams;
        }

        private List<GeoApiParam> ValidarInformacion(string[] rows)
        {
            var geoApiParams = new List<GeoApiParam>();

            var provincias = new GeoApiParam();
            var municipios = new GeoApiParam();
            var departamentos = new GeoApiParam();

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columnsRow = rows[i].Split(',');

                if (columnsRow[0] == string.Empty) break;
                columnsRow[4] = columnsRow[4].Replace("\r$", "");

                if (columnsRow[3] == "DEPARTAMENTO" && !departamentos.Param.Any(d => d.nombre == columnsRow[4]))
                {
                    departamentos.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
                else if (columnsRow[3] == "MUNICIPIO" && !municipios.Param.Any(m => m.nombre == columnsRow[4]))
                {
                    municipios.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
                else if (columnsRow[3] == "PROVINCIA" && !provincias.Param.Any(p => p.nombre == columnsRow[4]))
                {
                    provincias.Param.Add(new Param
                    {
                        nombre = columnsRow[4],
                        campos = "id,nombre",
                        max = 1,
                        exacto = true
                    });
                }
            }
            geoApiParams.Add(provincias);
            geoApiParams.Add(municipios);
            geoApiParams.Add(departamentos);

            return geoApiParams;
        }

        private bool ValidarFila(string[] columns, Tuple<List<Localizacion>,List<Localizacion>,List<Localizacion>>  results)
        {
            string nombreLoc = columns[4].Trim();
            string tipoLoc = columns[3];

            if (tipoLoc == "PROVINCIA" && results.Item1.Any(p => p.nombre == nombreLoc))
                return true;
            else if (tipoLoc == "MUNICIPIO" && results.Item2.Any(m => m.nombre == nombreLoc))
                return true;
            else if (tipoLoc == "DEPARTAMENTO" && results.Item3.Any(d => d.nombre == nombreLoc))
                return true;

            return false;
        }

        public async Task<Tuple<List<Localizacion>, List<Localizacion>, List<Localizacion>>> ConsultarAPI(List<GeoApiParam> parametros)
        {
            HttpClient httpClient = new HttpClient();

            List<string> urls = new List<string> { "provincias", "municipios", "departamentos" };

            object[] data = new object[] { new { provincias = parametros[0].Param }, new { municipios = parametros[1].Param }, new { departamentos = parametros[2].Param } };

            List<HttpResponseMessage> responses = new List<HttpResponseMessage>();

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

            List<Localizacion> provinciasResult = new List<Localizacion>();
            List<Localizacion> departamentosResult = new List<Localizacion>();
            List<Localizacion> municipiosResult = new List<Localizacion>();

            GeoApiResponse? provinciasContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[0].Content.ReadAsStringAsync());
            GeoApiResponse? municipiosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[1].Content.ReadAsStringAsync());
            GeoApiResponse? departamentosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[2].Content.ReadAsStringAsync());

            provinciasResult = provinciasContent != null ? provinciasContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.provincias[0])
                .ToList() : new List<Localizacion>();

            municipiosResult = municipiosContent != null ? municipiosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.municipios[0])
                .ToList() : new List<Localizacion>();

            departamentosResult = departamentosContent != null ? departamentosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.departamentos[0])
                .ToList() : new List<Localizacion>();

            return new Tuple<List<Localizacion>, List<Localizacion>, List<Localizacion>>(provinciasResult, municipiosResult, departamentosResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}