
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Usuario : Identidad
    {
        public Usuario() { }
        public Usuario(string correoElectronico, string contrasenia, bool activo, Persona persona)
        {
            CorreoElectronico = correoElectronico;
            Contrasenia = contrasenia;
            Activo = activo;
            Persona = persona;
        }
        

        public string CorreoElectronico { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }

        public int PersonaId { get; set; }

        [ForeignKey("Id")]
        public virtual Persona Persona { get; set; }
    }
}