
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Entidad : Identidad
    {
        public Entidad() {}
        public Entidad(string nombre, TipoEntidad tipoEntidad) 
        {
            Nombre = nombre;
            TipoEntidad = tipoEntidad;
            Servicios = new List<SuperServicio>();
        }

        public string Nombre { get; set; }
        [Column("TipoEntidad")]
        public TipoEntidad TipoEntidad { get; set; }
        [InverseProperty("Entidades")]
        public ICollection<Localizacion> Localizaciones { get; set; }
        [InverseProperty("Entidades")]
        public ICollection<SuperServicio> Servicios { get; set; }
        [InverseProperty("Entidades")]
        public ICollection<Organismo> Organismos{ get; set; }
        [InverseProperty("EntidadesInteresadas")]
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Sucursal> Sucursales { get; set; }
    }
}
