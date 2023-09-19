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
        [Column("Rol")]
        public Rol Rol { get; set; }
        public int ComunidadId { get; set; }
        public int PersonaId { get; set; }
        public int MedioId { get; set; }

        [ForeignKey("Id")]
        public virtual Comunidad Comunidad { get; set; }
        [ForeignKey("Id")]
        public virtual Persona Persona { get; set; }
        [ForeignKey("Id")]
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