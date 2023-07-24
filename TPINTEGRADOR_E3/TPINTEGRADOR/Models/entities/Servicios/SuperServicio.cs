
namespace TPINTEGRADOR.Models
{
    public abstract class SuperServicio : Identidad
    {
        public SuperServicio(string nombre, Entidad entidad, ProveedorDeServicio proveedor)
        {
            Nombre = nombre;
            Entidad = entidad;
            Proveedor = proveedor;
        }

        public string Nombre;
        public Entidad Entidad;
        public ProveedorDeServicio Proveedor;
    }
}
