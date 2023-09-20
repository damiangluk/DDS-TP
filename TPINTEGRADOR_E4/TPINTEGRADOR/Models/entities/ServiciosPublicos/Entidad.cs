
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
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
        [EnumDataType(typeof(TipoEntidad))]
        [Column(TypeName = "int")]
        public TipoEntidad TipoEntidad { get; set; }
        public ICollection<Localizacion> Localizaciones { get; set; }
        public ICollection<SuperServicio> Servicios { get; set; }
        public ICollection<Organismo> Organismos{ get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Sucursal> Sucursales { get; set; }
    }
}
