
namespace TPINTEGRADOR.Models
{
    public class Persona : Identidad
    {
        public Persona() { }
        public Persona(string nombre, string apellido, List<SuperServicio> intereses, List<Entidad> entidadesInteresadas, Localizacion localizacionDeInteres, Localizacion localizacionActual, List<Participacion> participaciones, List<DateTime> horariosParaNotificacion, Usuario usuario) 
        {
            Nombre = nombre;
            Apellido = apellido;
            Intereses = intereses;
            EntidadesInteresadas = entidadesInteresadas;
            LocalizacionDeInteres = localizacionDeInteres;
            LocalizacionActual = localizacionActual;
            Participaciones = participaciones;
            HorariosParaNotificacion = horariosParaNotificacion;
            Usuario = usuario;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<SuperServicio> Intereses;
        public List<Entidad> EntidadesInteresadas;
        public Localizacion LocalizacionDeInteres;
        public Localizacion LocalizacionActual;
        public List<Participacion> Participaciones;
        public List<DateTime> HorariosParaNotificacion;
        public virtual Usuario Usuario { get; set; }

        //intereses
        //entidadesInteresadas


        public void CambiarLocalizacion(Localizacion localizacion)
        {
            LocalizacionActual = localizacion;
            Participaciones.ForEach(p => p.Comunidad.AvisoCambioLocalizacion(this));
        }
    }
}
