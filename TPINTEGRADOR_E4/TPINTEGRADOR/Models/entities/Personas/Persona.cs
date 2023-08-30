
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Persona : Identidad
    {
        public Persona() { }
        public Persona(string nombre, string apellido, List<SuperServicio> intereses, Localizacion localizacionDeInteres, Localizacion localizacionActual, Usuario usuario) 
        {
            Nombre = nombre;
            Apellido = apellido;
            Intereses = intereses;
            LocalizacionDeInteres = localizacionDeInteres;
            LocalizacionActual = localizacionActual;
            Usuario = usuario;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int LocalizacionActualId { get; set; }
        public int LocalizacionDeInteresId { get; set; }


        [ForeignKey("LocalizacionDeInteresId")]
        public virtual Localizacion LocalizacionDeInteres { get; set; }

        [ForeignKey("LocalizacionActualId")]
        public virtual Localizacion LocalizacionActual { get; set; }

        public List<SuperServicio> Intereses;
        public virtual ICollection<Entidad> EntidadesInteresadas { get; set; }
        public virtual ICollection<Participacion> Participaciones { get; set; }
        public virtual ICollection<FechasNotificacion> HorariosParaNotificacion { get; set; }
        public virtual Usuario Usuario { get; set; }

        public void CambiarLocalizacion(Localizacion localizacion)
        {
            LocalizacionActual = localizacion;
            Participaciones.ToList().ForEach(p => p.Comunidad.AvisoCambioLocalizacion(this));
        }
    }
}
