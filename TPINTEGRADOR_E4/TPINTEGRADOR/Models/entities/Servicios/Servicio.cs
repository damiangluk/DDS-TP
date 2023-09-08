using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class Servicio : SuperServicio
    {
        #region constructores
        public Servicio() { }
        public Servicio(string descripcion, string nombre, ProveedorDeServicio proveedor)
        {
            Descripcion = descripcion;
            Nombre = nombre;
            Proveedor = proveedor;
        }
        #endregion

        #region propiedades
        public string Descripcion { get; set; }

        [InverseProperty("Servicios")]
        public ICollection<ServicioAgrupado> Agrupaciones { get; set; }
        #endregion
    }
}
