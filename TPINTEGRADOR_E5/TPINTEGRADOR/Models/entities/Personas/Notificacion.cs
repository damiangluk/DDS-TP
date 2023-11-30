
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Notificacion : Identidad
    {
        #region constructores
        public Notificacion() { }

        public Notificacion(DateTime fecha, Persona persona, string mensaje ) 
        {
            Persona = persona;
            Fecha = fecha;
            Mensaje = mensaje;
            Entregado = false;
        }
        #endregion
        #region propiedades
        public int PersonaId { get; set; }
        public bool Entregado { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("PersonaId")]
        public virtual Persona Persona { get; set; }
        #endregion
    }
}
