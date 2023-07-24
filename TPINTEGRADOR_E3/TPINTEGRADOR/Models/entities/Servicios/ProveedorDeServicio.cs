namespace TPINTEGRADOR.Models
{
    public abstract class ProveedorDeServicios : Identidad
    {
        public ProveedorDeServicios(string nombre, List<SuperServicio> superServicio, List<Incidente> incidentes)
        {
            Nombre = nombre;
            SuperServicio = superServicio;
            Incidentes = incidente;
        }

        public string Nombre;
        public List<Incidente> Incidentes;
        public List<SuperServicio> SuperServicio;
    }
}