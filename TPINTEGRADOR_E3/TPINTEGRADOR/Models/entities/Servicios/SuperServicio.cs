
namespace TPINTEGRADOR.Models
{
    public abstract class SuperServicio : Identidad
    {
        public SuperServicio(string nombre, Entidad entidad)
        {
            Nombre = nombre;
            Entidad = entidad;
        }

        public string Nombre;
        public Entidad Entidad;

    }
}
