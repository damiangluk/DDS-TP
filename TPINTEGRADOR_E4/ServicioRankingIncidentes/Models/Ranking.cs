using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.Sistema;

namespace ServicioRankingIncidentes.Models
{
    public class Ranking
    {
        public static List<Entidad> generarRanking()
        {

            var DB = DBContext.CreateDbContext();
            List<Entidad> entities = DB.Entidades.ToList();

            return entities;
        }

    }
}
