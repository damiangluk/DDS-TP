
using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class Entidad
    {
        string Nombre { get; set; }
        TipoEntidad Tipo { get; set; }
        //Sucursales
        Localizacion Localizacion { get; set; }
    }
}
