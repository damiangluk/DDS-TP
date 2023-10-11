using Microsoft.EntityFrameworkCore;
using TPINTEGRADOR.Models;
using TPINTEGRADOR.Models.entities.ServicioRanking;
using TPINTEGRADOR.Models.Sistema;

namespace ServicioRankingIncidentes.Models
{
    public class Ranking
    {
        public static List<Tuple<int, string, int>> generarRankingImpactoIncidentes(DBContext DB,int cnf = 10)
        {

            //var DB = DBContext.CreateDbContext();
            List<Entidad> entities = DB.Entidades.ToList();
            
            var incidentsXEntities = entities
                .Select(e => new Tuple<Entidad, List<Incidente>> (
                    e,
                    e.Servicios.SelectMany(s => s.Incidentes).Where(i => i.ImpactoEnLaSemana()).ToList()
                 ));
            var newList = new List<Tuple<int, string, int>>();

            foreach (var entity in incidentsXEntities)
            {
                int acumuladorTiemposDeResolucion = 0;
                int contadorIncidentesAbiertos = 0;
                int result = CalcularImpactoEntidad(cnf, entity, ref acumuladorTiemposDeResolucion, ref contadorIncidentesAbiertos);
                newList.Add(new Tuple<int, string, int>(entity.Item1.Id, entity.Item1.Nombre, result));
            }
            //DB.Dispose();
            return newList.OrderByDescending(e => e.Item3).ToList();
        }

        private static int CalcularImpactoEntidad(int cnf, Tuple<Entidad, List<Incidente>>? entity, ref int acumuladorTiemposDeResolucion, ref int contadorIncidentesAbiertos)
        {
            foreach(var e in entity.Item2)
            {
                if (e.EstaAbierto())
                {
                    contadorIncidentesAbiertos++;
                }
                else
                {
                    acumuladorTiemposDeResolucion += e.CalcularTiempoDeCierre();
                }
            };
            int result = acumuladorTiemposDeResolucion + contadorIncidentesAbiertos * cnf;
            return result;
        }
    }
}
