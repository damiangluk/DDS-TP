using Microsoft.EntityFrameworkCore;
using TPINTEGRADOR.Models.entities.ServicioRanking;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class RankingDao : GenericDao<Ranking>
    {
        public List<Ranking> GetAllByDates(DateTime fechaInicio, DateTime fechaFin, TipoRanking? tipo = null) {

            var query = context.ImpactoIncidentes
            .Where(t => t.Fecha > fechaInicio && t.Fecha < fechaFin);

            if (tipo.HasValue)
            {
                query = context.ImpactoIncidentes
                .Where(t => t.Fecha > fechaInicio && t.Fecha < fechaFin)
                .Where(t => t.TipoRanking == tipo.Value);     
            }

            return query.ToList();
        }
    }
}
