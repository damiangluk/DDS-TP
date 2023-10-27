
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Usuario : Identidad
    {
        #region constructores
        public Usuario() { }
        public Usuario(string correoElectronico, string token, Persona? persona)
        {
            CorreoElectronico = correoElectronico;
            Token = token;
            Persona = persona;
            PersonaId = Persona?.Id;
            Activo = true;
        }
        #endregion

        #region propiedades
        public string CorreoElectronico { get; set; }
        public string Token { get; set; }
        public bool Activo { get; set; }
        public int? PersonaId { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Persona Persona { get; set; }
        #endregion
    }
}