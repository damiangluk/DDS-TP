using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    [Table("Rankings")]
    public class Ranking : Identidad
    {
        #region constructores
        
        public Ranking() { }

        public Ranking(string json, DateTime fechaRanking, TipoRanking tipoRanking)
        {
            Json = json;
            Fecha = fechaRanking;
            TipoRanking = tipoRanking;
        }
        #endregion

        #region propiedades
        public string Json { get; set; }
        public DateTime Fecha { get; set; }
        public TipoRanking TipoRanking { get; set; }
        #endregion

        #region metodos
        //{{idEnt: int,  nombreEnt: string, impacto: int}, ....}

        public List<Tuple<int, string, int>> DeserializarRanking()
        {
            return JsonConvert.DeserializeObject<List<Tuple<int, string, int>>>(Json);
        }
        #endregion
    }
}
