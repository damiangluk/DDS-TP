using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Migrations;
using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    public class RankingMayorImpacto : RankingBase
    {
        private readonly int CNF = 10;

        public override Ranking GenerarRanking()
        {
            var ranking = new List<Tuple<int, string, int>>();
            var incidentesNecesarios = DataFactory.IncidenteDao.FindWithWeeklyImpact();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);

            foreach (var entity in diccionario)
            {
                int result = CalcularImpactoEntidad(entity.Value);
                ranking.Add(new Tuple<int, string, int>(entity.Key.Id, entity.Key.Nombre, result));
            }

            var rankingOrdered = ranking.OrderByDescending(r => r.Item3);
            return new Ranking(JsonHelper.SerializeObject(ranking, 2), DateTime.Now, TipoRanking.TIEMPOPROMEDIO);
        }

        private int CalcularImpactoEntidad(List<Incidente> incidents)
        {
            int acumuladorTiemposDeResolucion = 0, contadorIncidentesAbiertos = 0;

            foreach (var e in incidents)
            {
                if (e.EstaAbierto())
                    contadorIncidentesAbiertos++;
                else
                    acumuladorTiemposDeResolucion += e.CalcularTiempoDeCierre();
            };

            return acumuladorTiemposDeResolucion + contadorIncidentesAbiertos * CNF;
        }
    }
}
