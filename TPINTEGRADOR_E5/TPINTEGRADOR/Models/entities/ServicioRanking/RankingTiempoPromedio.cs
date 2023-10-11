using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    public class RankingTiempoPromedio : RankingBase
    {
        public override Ranking GenerarRanking()
        {
            var ranking = new List<Tuple<int, string, double>>();
            var incidentesNecesarios = DataFactory.IncidenteDao.FindCloseWeekly();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);

            foreach (var entity in diccionario)
            {
                double result = entity.Value.Average(e => e.CalcularTiempoDeCierre());
                ranking.Add(new Tuple<int, string, double>(entity.Key.Id, entity.Key.Nombre, result));
            }

            var rankingOrdered = ranking.OrderByDescending(r => r.Item3);
            return new Ranking(JsonHelper.SerializeObject(ranking, 2), DateTime.Now, TipoRanking.TIEMPOPROMEDIO);
        }
    }
}
