using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Establecimiento : Identidad
    {
        #region constructores
        public Establecimiento() { }
        public Establecimiento(Ubicacion ubicacion, string nombre)
        {
            Ubicacion = ubicacion;
            Nombre = nombre;
        }
        #endregion

        #region propiedades
        public string Nombre { get; set; }
        public int UbicacionId { get; set; }
        
        [ForeignKey("UbicacionId")]
        public virtual Ubicacion Ubicacion { get; set; }
        public virtual ICollection<Sucursal> Sucursales { get; set; }
        public virtual ICollection<Prestacion> Prestaciones { get; set; }
        #endregion
    }
}