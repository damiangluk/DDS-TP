using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    public class RankingMayorCantidadIncidentes : RankingBase
    {
        public override Ranking GenerarRanking()
        {
            var ranking = new List<Tuple<int, string, int>>();
            var incidentesNecesarios = DataFactory.IncidenteDao.FindCloseWeeklyWithoutToday();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);

            foreach (var entity in diccionario)
            {
                int result = entity.Value.Count();
                ranking.Add(new Tuple<int, string, int>(entity.Key.Id, entity.Key.Nombre, result));
            }

            var rankingOrdered = ranking.OrderByDescending(r => r.Item3);
            return new Ranking(JsonHelper.SerializeObject(ranking, 2), DateTime.Now, TipoRanking.TIEMPOPROMEDIO);
        }
    }
}
