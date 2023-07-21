
namespace TPINTEGRADOR.Models
{
    public class Comunidad : Identidad
    {
        public Comunidad(List<SuperServicio> intereses, List<Incidente> incidentes, int cantidadMiembrosAfectados, Persona administrador) 
        {
            Miembros = new List<Participacion>();
            Intereses = intereses;
            Incidentes = incidentes;
            CantidadMiembrosAfectados = cantidadMiembrosAfectados;
            Administrador = administrador;
        }

        public List<Participacion> Miembros;
        public List<SuperServicio> Intereses;
        public List<Incidente> Incidentes;
        public int CantidadMiembrosAfectados;
        public Persona Administrador;
        //intereses
        //entidadesInteresadas
        //localizacionDeInteres
        public void AvisoCambioLocalizacion(Persona persona)
        {  
            List<Incidente> incidentes = Incidentes.Where(i => i.Localizacion == persona.LocalizacionActual).ToList();
            //incidentes.ForEach(i => sugerirInforme(persona,i));
        }
    }
}
