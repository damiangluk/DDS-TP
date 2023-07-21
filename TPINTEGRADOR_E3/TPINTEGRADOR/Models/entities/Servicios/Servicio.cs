using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Servicio : SuperServicio
    {
        public Servicio(string descripcion, string nombre) : base(nombre)
        {
            Descripcion = descripcion;
        }

        public string Descripcion;
    }
}
