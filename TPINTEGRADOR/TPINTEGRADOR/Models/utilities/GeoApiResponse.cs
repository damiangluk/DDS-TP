
namespace TPINTEGRADOR.Models
{
    public class GeoApiResponse
    {
        public List<Resultado> resultados { get; set; } = new List<Resultado>();
    }

    public class Resultado
    {
        public int cantidad { get; set; }
        public List<Localizacion> provincias { get; set; } = new List<Localizacion>();
        public List<Localizacion> municipios { get; set; } = new List<Localizacion>();
        public List<Localizacion> departamentos { get; set; } = new List<Localizacion>();

    }

    public class LocalizacionAPI
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
    }
}
