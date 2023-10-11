using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models.entities.ServicioRanking
{
    public abstract class RankingBase
    {
        public abstract Ranking GenerarRanking();

        protected Dictionary<Entidad, List<Incidente>> AgruparIncidentesPorEntidad(List<Incidente> incidentes)
        {
            Dictionary<Entidad, List<Incidente>> diccionario = new Dictionary<Entidad, List<Incidente>>();

            foreach (var incidente in incidentes)
            {
                foreach (var entidad in incidente.Servicio.Entidades)
                {
                    if (!diccionario.ContainsKey(entidad))
                    {
                        diccionario[entidad] = new List<Incidente>();
                    }

                    diccionario[entidad].Add(incidente);
                }
            }

            return diccionario;
        }
    }
}
