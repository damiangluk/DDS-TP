using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public static class IncidenteDao
    {
        private static DBContext context = DBContext.CreateDbContext();

        public static void CrearIncidente(Incidente incidente, int idServicio)
        {
            SuperServicio servicio = context.Servicios.ToList().Find(s => s.Id == idServicio);
            incidente.Servicio = servicio;
            context.Incidentes.Add(incidente);
            servicio.Incidentes.Add(incidente);
            servicio.Comunidades.ToList().ForEach(c => c.NotificarMiembros(incidente));
        }

        public static void CerrarIncidente(int idIncidente)
        {
            Incidente incidente = context.Incidentes.ToList().Find(i => i.Id == idIncidente);
            incidente.FechaCierre = DateTime.Now;
        }

        public static List<Incidente> ConsultarIncidentePorEstado(bool? estado)
        {
            if (!estado.HasValue)
                return context.Incidentes.ToList();

            return context.Incidentes.ToList().Where(i => i.EstaAbierto() == estado).ToList();
        }

        public static List<Entidad> RankingEntidadesTiempoPromedioIncidentesParaProveedor(ProveedorDeServicio proveedor)
        {
            var incidentesNecesarios = context.Incidentes.ToList().Where(i => i.Servicio.Proveedor.Equals(proveedor) && !i.EstaAbierto() && (DateTime.Now - i.FechaApertura).TotalDays <= 7).ToList();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);
            return diccionario.Keys.OrderByDescending(e => diccionario[e].Average(e => e.CalcularTiempoDeCierre())).ToList();
        }


        public static List<Entidad> RankingEntidadesMayorCantidadIncidentesParaProveedor(ProveedorDeServicio proveedor)
        {
            var incidentesNecesarios = context.Incidentes.ToList().Where(i => i.Servicio.Proveedor.Equals(proveedor) && (!i.EstaAbierto() || (DateTime.Now - i.FechaApertura).TotalHours > 24) && (DateTime.Now - i.FechaApertura).TotalDays <= 7).ToList();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);
            return diccionario.Keys.OrderByDescending(e => diccionario[e].Count()).ToList();
        }

        public static List<Entidad> RankingEntidadesTiempoPromedioIncidentesParaOrganismo(Organismo organismo)
        {
            var incidentesNecesarios = organismo.Entidades.SelectMany(e => e.Servicios).SelectMany(s => s.Incidentes)
                .Where(i => !i.EstaAbierto() && (DateTime.Now - i.FechaApertura).TotalDays <= 7).ToList();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);
            return diccionario.Keys.OrderByDescending(e => diccionario[e].Average(e => e.CalcularTiempoDeCierre())).ToList();
        }


        public static List<Entidad> RankingEntidadesMayorCantidadIncidentesParaOrganismo(Organismo organismo)
        {
            var incidentesNecesarios = organismo.Entidades.SelectMany(e => e.Servicios).SelectMany(s => s.Incidentes)
                .Where(i => (!i.EstaAbierto() || (DateTime.Now - i.FechaApertura).TotalHours > 24) && (DateTime.Now - i.FechaApertura).TotalDays <= 7).ToList();
            var diccionario = AgruparIncidentesPorEntidad(incidentesNecesarios);
            return diccionario.Keys.OrderByDescending(e => diccionario[e].Count()).ToList();
        }

        private static Dictionary<Entidad, List<Incidente>> AgruparIncidentesPorEntidad(List<Incidente> incidentes)
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
