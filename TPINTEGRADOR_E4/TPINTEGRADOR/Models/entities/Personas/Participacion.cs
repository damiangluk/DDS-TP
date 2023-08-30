using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Participacion : Identidad
    {
        public Participacion() { }
        public Participacion(Persona persona, Comunidad comunidad, Rol rol, Medio medio)
        {
            Persona = persona;
            Comunidad = comunidad;
            Rol = rol;
            Medio = medio;
        }


        public Rol Rol { get; set; }
        public int PersonaId { get; set; }
        public int ComunidadId { get; set; }
        public int MedioId { get; set; }

        [ForeignKey("Id")]
        public virtual Persona Persona { get; set; }
        [ForeignKey("Id")]
        public virtual Comunidad Comunidad { get; set; }
        [ForeignKey("Id")]
        public virtual Medio Medio { get; set; }
        [Column("Rol")]
        public int RolValue
        {
            get { return (int)Rol; }
            private set { Rol = (Rol)value; }
        }

        public void NotificarIncidente(Incidente incidente)
        {
            Medio.Notificar(incidente.Informe, Persona);
        }

        public void cambiarRol(Rol rol)
        {
            Rol = rol;
        }
    }
}