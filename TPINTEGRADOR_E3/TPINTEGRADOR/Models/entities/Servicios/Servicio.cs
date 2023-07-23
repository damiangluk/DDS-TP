namespace TPINTEGRADOR.Models
{
    public class Servicio : SuperServicio
    {
        public Servicio(string descripcion, string nombre, Entidad entidad) : base(nombre, entidad)
        {
            Descripcion = descripcion;
        }

        public string Descripcion;
    }
}
