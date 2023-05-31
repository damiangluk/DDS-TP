
using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class Entidad : Identidad
    {
        public Entidad(string nombre, TipoEntidad tipoEntidad, Localizacion localizacion) 
        {
            Nombre = nombre;
            TipoEntidad = tipoEntidad;
            Localizacion = localizacion;
        }

        public string Nombre;
        public TipoEntidad TipoEntidad;
        public Localizacion Localizacion;
        //Sucursales
    }
}
