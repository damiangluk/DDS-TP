
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class FechasNotificacion : Identidad
    {

        public FechasNotificacion() { }

        public FechasNotificacion(DateTime fecha, Persona persona) 
        {
            Persona = persona;
            Fecha = fecha;
        }

        public int PersonaId { get; set; }
        [ForeignKey("Id")]
        public virtual Persona Persona { get; set; }
        public DateTime Fecha { get; set; }
    }
}
