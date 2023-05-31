
using Microsoft.AspNetCore.Identity;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Organismo : Identidad
    {
        public Organismo(TipoOrganismo tipoOrganismo, Persona encargado, Entidad entidad)
        {
            TipoOrganismo = tipoOrganismo;
            Encargado = encargado;
            Entidad = entidad;
        }

        public TipoOrganismo TipoOrganismo;
        public Persona Encargado;
        public Entidad Entidad;
    }
}