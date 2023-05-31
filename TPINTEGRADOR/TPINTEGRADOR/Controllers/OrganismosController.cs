using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Cryptography;
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
            Sistema system = Sistema.GetInstance;
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

            var rowsError = "";
            Tuple<List<LocalizacionAPI>, List<LocalizacionAPI>, List<LocalizacionAPI>> results;

            try
            {
                List<GeoApiParam> parametros = CargarParametros(rows);
                results = await ConsultarAPI(parametros);

                for(int i = 1; i < (rows.Length - 1); i++)
                {
                    Organismo? organismo = ConvertirFilaAOrganismo(rows[i]);

                    if (organismo != null && ValidarFila(organismo, results))
                    {
                        system.AgregarOrganismo(organismo);
                    }
                    else
                        rowsError += (i + ",");
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
                rowsError = "Las siguientes filas son invalidas: " + rowsError.Substring(0, rowsError.Length - 1);
            }

            object result = new
            {
                status = true,
                validation = true,
                content = new { 
                    rowsError,
                    organismos = OrganismosForFront(system.Organismos),
                }
            };

            var aa = JsonHelper.SerializeObject(result, 4);
            return aa;
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

        private bool ValidarFila(Organismo organismo, Tuple<List<LocalizacionAPI>,List<LocalizacionAPI>,List<LocalizacionAPI>>  results)
        {
            string nombreLoc = organismo.Entidad.Localizacion.Nombre;
            TipoLocalizacion tipoLoc = organismo.Entidad.Localizacion.TipoLocalizacion;

            return Enum.IsDefined(typeof(TipoLocalizacion), tipoLoc) &&
                (results.Item1.Any(p => p.nombre == nombreLoc) || results.Item2.Any(m => m.nombre == nombreLoc) || results.Item3.Any(d => d.nombre == nombreLoc));
        }

        public async Task<Tuple<List<LocalizacionAPI>, List<LocalizacionAPI>, List<LocalizacionAPI>>> ConsultarAPI(List<GeoApiParam> parametros)
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

            List<LocalizacionAPI> provinciasResult = new List<LocalizacionAPI>();
            List<LocalizacionAPI> departamentosResult = new List<LocalizacionAPI>();
            List<LocalizacionAPI> municipiosResult = new List<LocalizacionAPI>();

            GeoApiResponse? provinciasContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[0].Content.ReadAsStringAsync());
            GeoApiResponse? municipiosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[1].Content.ReadAsStringAsync());
            GeoApiResponse? departamentosContent = JsonConvert.DeserializeObject<GeoApiResponse>(await responses[2].Content.ReadAsStringAsync());

            provinciasResult = provinciasContent != null ? provinciasContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.provincias[0])
                .ToList() : new List<LocalizacionAPI>();

            municipiosResult = municipiosContent != null ? municipiosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.municipios[0])
                .ToList() : new List<LocalizacionAPI>();

            departamentosResult = departamentosContent != null ? departamentosContent.resultados
                .Where(res => res.cantidad > 0)
                .Select(res => res.departamentos[0])
                .ToList() : new List<LocalizacionAPI>();

            return new Tuple<List<LocalizacionAPI>, List<LocalizacionAPI>, List<LocalizacionAPI>>(provinciasResult, municipiosResult, departamentosResult);
        }

        private Organismo? ConvertirFilaAOrganismo(string row)
        {
            string[] columns = row.Split(',');
            TipoOrganismo? tipoOrganismo = TipoOrganismoExtensions.GetType(columns[0].Trim());
            string nombreEntidad = columns[1].Trim();
            TipoEntidad? tipoEntidad = TipoEntidadExtensions.GetType(columns[2].Trim());
            TipoLocalizacion? tipoLocalizacionEntidad = TipoLocalizacionExtensions.GetType(columns[3].Trim());
            string nombreLocalizacionEntidad = columns[4].Trim();
            string nombreEncargado = columns[5].Trim();
            string apellidoEncargado = columns[6].Trim();
            string correoEncargado = columns[7].Trim();
            string contraseniaEncargado = columns[8].Trim();

            if (!tipoOrganismo.HasValue || !tipoEntidad.HasValue || !tipoLocalizacionEntidad.HasValue)
                return null;

            Persona encargado = new Persona(nombreEncargado, apellidoEncargado, correoEncargado, contraseniaEncargado);
            Localizacion localizacion = new Localizacion(tipoLocalizacionEntidad.Value, nombreLocalizacionEntidad);
            Entidad entidad = new Entidad(nombreEntidad, tipoEntidad.Value, localizacion);
            Organismo organismo = new Organismo(tipoOrganismo.Value, encargado, entidad);

            return organismo;
        }

        private List<object> OrganismosForFront(List<Organismo> organismos)
        {
            List<object> organismosFront = new List<object>();
            
            foreach(Organismo org in organismos)
            {
                var orgFront = new
                {
                    TipoOrganismo = TipoOrganismoExtensions.GetNombre(org.TipoOrganismo),
                    EntidadNombre = org.Entidad.Nombre,
                    TipoEntidad = TipoEntidadExtensions.GetNombre(org.Entidad.TipoEntidad),
                    TipoLocalizacion = TipoLocalizacionExtensions.GetNombre(org.Entidad.Localizacion.TipoLocalizacion),
                    NombreLocalizacion = org.Entidad.Localizacion.Nombre,
                    EncargadoNombre = org.Encargado.Nombre,
                    EncargadoApellido = org.Encargado.Apellido,
                    EncargadoCorreoElectronico = org.Encargado.CorreoElectronico,
                    EncargadoContrasenia = org.Encargado.Contrasenia
                };

                organismosFront.Add(orgFront);
            }

            return organismosFront;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}