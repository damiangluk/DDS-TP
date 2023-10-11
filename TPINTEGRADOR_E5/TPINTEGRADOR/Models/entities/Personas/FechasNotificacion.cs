
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class FechasNotificacion : Identidad
    {
        #region constructores
        public FechasNotificacion() { }

        public FechasNotificacion(DateTime fecha, Persona persona) 
        {
            Persona = persona;
            Fecha = fecha;
        }
        #endregion

        #region propiedades
        public int PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("PersonaId")]
        public virtual Persona Persona { get; set; }
        #endregion
    }
}
