namespace TPINTEGRADOR.Models
{

    public sealed class SistemaServicios
    {
        #region instance
        private static readonly SistemaServicios instance = new SistemaServicios();

        private SistemaServicios() { }

        public static SistemaServicios GetInstance
        {
            get { return instance; }
        }
        #endregion

        #region properties

        public List<Incidente> Incidentes { get; set; } = new List<Incidente>();

        #endregion

        #region methods

        public void CrearIncidente(Incidente incidente, int idComunidad)
        {   
            Comunidad comunidad = Comunidades.Find(c => c.Id == idComunidad);
            incidente.Comunidad = comunidad;
            Incidentes.Add(incidente);
            comunidad.Incidentes.Add(incidente);
            Participaciones.Where(p => p.Comunidad.Id == idComunidad).ToList().ForEach(p => p.NotificarIncidente(incidente));
        }

        public void CerrarIncidente(int idIncidente, int idComunidad)
        {      
            Incidente incidente = Incidentes.Find(i => i.Id == idIncidente && i.Comunidad.Id == idComunidad);
            incidente.FechaCierre = DateTime.Now;
        }
        
        public List<Incidente> ConsultarIncidentePorEstado(bool? estado)
        {
            if(!estado.HasValue)
                return Incidentes;

            return Incidentes.Where(i => i.EstaAbierto() == estado).ToList();
        }

        public List<Entidad> GenerarRanking()
        {
            Dictionary<Entidad, List<Incidente>> diccionario = new Dictionary<Entidad, List<Incidente>>();
            foreach(var incidente in Incidentes)
            {
                if(indicente.EstaAbierto()) continue;
                
                foreach(var entidad in incidente.Entidades)
                {
                    if (!diccionario.ContainsKey(entidad))
                    {
                        diccionario[entidad] = new List<Incidente>();
                    }

                    diccionario[entidad].Add(incidente);
                }
            }
            return diccionario.Keys.OrderBy(e => diccionario[e].Average(e => e.CalcularTiempoDeCierre()));
        }

        #endregion
    }
}