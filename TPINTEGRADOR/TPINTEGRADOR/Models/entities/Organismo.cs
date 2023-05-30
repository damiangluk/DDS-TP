
using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class Organismo
    {
        public Organismo(TipoOrganismo tipoOrganismo, Persona encargado, Entidad entidad)
        {
            TipoOrganismo = tipoOrganismo;
            Encargado = encargado;
            Entidad = entidad;
        }

        TipoOrganismo TipoOrganismo { get; set; }
        Persona Encargado { get; set; }
        Entidad Entidad { get; set; }
    }
}
