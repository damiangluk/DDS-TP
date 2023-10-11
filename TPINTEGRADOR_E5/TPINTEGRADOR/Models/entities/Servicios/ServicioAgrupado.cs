using System.ComponentModel.DataAnnotations.Schema;

namespace TPINTEGRADOR.Models
{
    public class ServicioAgrupado : SuperServicio
    {
        #region constructores
        public ServicioAgrupado() { }
        public ServicioAgrupado(string nombre, ProveedorDeServicio proveedor)
        {
            Nombre = nombre;
            Proveedor = proveedor;
        }
        #endregion

        #region propiedades
        public ICollection<Servicio> Servicios { get; set; }
        #endregion
    }
}