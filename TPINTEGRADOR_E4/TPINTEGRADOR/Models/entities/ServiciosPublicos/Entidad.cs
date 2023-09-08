
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
        public TipoEntidad TipoEntidad { get; set; }
        public ICollection<Localizacion> Localizaciones { get; set; }
        [InverseProperty("Entidades")]
        public ICollection<SuperServicio> Servicios { get; set; }

        [Column("TipoEntidad")]
        public int TipoEntidadValue { get { return (int)TipoEntidad; } private set { TipoEntidad = (TipoEntidad)value; } }
        //Sucursales
    }
}
