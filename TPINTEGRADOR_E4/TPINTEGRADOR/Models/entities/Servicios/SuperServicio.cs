
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public abstract class SuperServicio : Identidad
    {
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }

        [ForeignKey("Id")]
        public virtual ProveedorDeServicio Proveedor { get; set; }

        [InverseProperty("Servicios")]
        public virtual ICollection<Entidad> Entidades { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
        [InverseProperty("Intereses")]
        public virtual ICollection<Comunidad> Comunidades { get; set; }
        [InverseProperty("Intereses")]
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Prestacion> Prestaciones{ get; set; }
    }
}
