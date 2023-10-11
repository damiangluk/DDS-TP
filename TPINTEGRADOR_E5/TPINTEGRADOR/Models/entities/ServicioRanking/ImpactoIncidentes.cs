using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    public class ImpactoIncidentes : Identidad
    {
        #region constructores
        public ImpactoIncidentes() { }

        public ImpactoIncidentes(string ranking, DateTime fechaRanking) {
            Ranking = ranking;
            FechaRanking = fechaRanking;
        }
        #endregion

        #region propiedades
        public string Ranking { get; set; }
        public DateTime FechaRanking { get; set; }
        #endregion

        #region metodos
        //{{idEnt: int,  nombreEnt: string, impacto: int}, ....}

        public List<Tuple<int, string, int>> DeserializarRanking()
        {
            return JsonConvert.DeserializeObject<List<Tuple<int, string, int>>>(Ranking);
        }
        #endregion
    }
}
