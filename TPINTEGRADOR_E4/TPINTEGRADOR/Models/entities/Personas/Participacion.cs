using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Participacion : Identidad
    {
        #region constructores
        public Participacion() { }
        public Participacion(Persona persona, Comunidad comunidad, Rol rol, Medio medio)
        {
            Persona = persona;
            Comunidad = comunidad;
            Rol = rol;
            Medio = medio;
        }
        #endregion

        #region propiedades
        [EnumDataType(typeof(Rol))]
        [Column(TypeName = "int")]
        public Rol Rol { get; set; }
        public int ComunidadId { get; set; }
        public int PersonaId { get; set; }
        public int MedioId { get; set; }

        [ForeignKey("ComunidadId")]
        public virtual Comunidad Comunidad { get; set; }
        [ForeignKey("PersonaId")]
        public virtual Persona Persona { get; set; }
        [ForeignKey("MedioId")]
        public virtual Medio Medio { get; set; }
        #endregion

        #region metodos
        public void NotificarIncidente(Incidente incidente)
        {
            Medio.Notificar(incidente.Informe, Persona);
        }

        public void cambiarRol(Rol rol)
        {
            Rol = rol;
        }
        #endregion
    }
}