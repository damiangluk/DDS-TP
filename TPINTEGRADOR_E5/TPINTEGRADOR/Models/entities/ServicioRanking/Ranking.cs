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

        public class Entidad
        {
            public int idEnt { get; set; }
            public string nombreEnt { get; set; }
            public int impacto { get; set; }

      
        }

        public List<Entidad> DeserializarRanking()
        {
            //List<Tuple<int, string, int>> variable = JsonConvert.DeserializeObject<List<Tuple<int, string, int>>>(Json);
            List<Entidad> listaDeserializada = JsonConvert.DeserializeObject<List<Entidad>>(Json);

            return listaDeserializada;
        }
        #endregion
    }
}
