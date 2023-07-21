namespace TPINTEGRADOR.Models
{
    public sealed class SistemaPersonas
    {
        #region instance
        
        private static readonly SistemaPersonas instance = new SistemaPersonas();

        private SistemaPersonas() { }

        public static SistemaPersonas GetInstance
        {
            get { return instance; }
        }
        
        #endregion

        #region properties
        
        public List<Incidente> Incidentes { get; set; } = new List<Incidente>();
        public List<Comunidad> Comunidades { get; set; } = new List<Comunidad>();
        
        #endregion

        public void CrearIncidente(Incidente incidente, int idComunidad)
        {   
            Comunidad comunidad = Comunidades.FirstOrDefault(c => c.Id == idComunidad);
            incidente.Comunidad = comunidad;
            Incidentes.Add(incidente);
            comunidad.Incidentes.Add(incidente);
        }

        public void CerrarIncidente(int idIncidente, int idComunidad)
        {      
            Incidente incidente = Incidentes.FirstOrDefault(i => i.Id == idIncidente && i.Comunidad.Id == idComunidad);
            incidente.FechaCierre = DateTime.Now;
        }
        
        public List<Incidente> consultarIncidentePorEstado(bool? estado)
        {
            if(!estado.HasValue)
                return Incidentes;

            return Incidentes.Where(i => i.EstaAbierto() == estado).ToList();
        }
    }
}