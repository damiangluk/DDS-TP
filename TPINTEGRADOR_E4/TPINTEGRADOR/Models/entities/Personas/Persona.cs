
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Persona : Identidad
    {
        #region constructores
        public Persona() { }
        public Persona(string nombre, string apellido, Localizacion localizacionDeInteres, Localizacion localizacionActual, Usuario usuario) 
        {
            Nombre = nombre;
            Apellido = apellido;
            LocalizacionDeInteres = localizacionDeInteres;
            LocalizacionActual = localizacionActual;
            Usuario = usuario;
        }
        #endregion

        #region propiedades
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int LocalizacionActualId { get; set; }
        public int LocalizacionDeInteresId { get; set; }

        [ForeignKey("LocalizacionDeInteresId")]
        public virtual Localizacion LocalizacionDeInteres { get; set; }
        [ForeignKey("LocalizacionActualId")]
        public virtual Localizacion LocalizacionActual { get; set; }
        public virtual Usuario Usuario { get; set; }
        [InverseProperty("Personas")]
        public virtual ICollection<SuperServicio> Intereses { get; set; }
        public virtual ICollection<Entidad> EntidadesInteresadas { get; set; }
        public virtual ICollection<Participacion> Participaciones { get; set; }
        public virtual ICollection<FechasNotificacion> HorariosParaNotificacion { get; set; }
        #endregion

        #region metodos
        public void CambiarLocalizacion(Localizacion localizacion)
        {
            LocalizacionActual = localizacion;
            Participaciones.ToList().ForEach(p => p.Comunidad.AvisoCambioLocalizacion(this));
        }
        #endregion
    }
}
