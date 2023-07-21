
namespace TPINTEGRADOR.Models
{
    public class Incidente : Identidad
    {
        public Incidente(Comunidad comunidad, SuperServicio servicio, DateTime fechaApertura, DateTime fechaCierre, Localizacion localizacion, string observaciones, string estado)
        {
            Comunidad = comunidad;
            Servicio = servicio;
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            Localizacion = localizacion;
            Observaciones = observaciones;
            Estado = estado;
        }

        public Comunidad Comunidad;
        public SuperServicio Servicio;
        public DateTime? FechaApertura;
        public DateTime? FechaCierre;
        public Localizacion Localizacion;
        public string Observaciones;
        public string Estado;

        public bool EstaAbierto()
        {
            return !FechaCierre.HasValue;
        }
    }
}