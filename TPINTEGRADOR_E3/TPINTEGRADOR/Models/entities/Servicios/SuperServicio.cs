
using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class SuperServicio : Identidad
    {
        public SuperServicio(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre;
    }
}
