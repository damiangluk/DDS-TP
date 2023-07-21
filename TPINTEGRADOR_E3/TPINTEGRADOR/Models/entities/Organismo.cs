
using Microsoft.AspNetCore.Identity;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models
{
    public class Organismo : Identidad
    {
        public Organismo(TipoOrganismo tipoOrganismo, string nombre, Persona encargado, Entidad entidad)
        {
            TipoOrganismo = tipoOrganismo;
            Nombre = nombre;
            Encargado = encargado;
        }         

        public Organismo(TipoOrganismo tipoOrganismo, string nombre)
        {
            TipoOrganismo = tipoOrganismo;
            Nombre = nombre;
        }

        public TipoOrganismo TipoOrganismo;
        public string Nombre;
        public Persona Encargado;        public Entidad Entidad;

        public object OrganismosForFront()
        {
            object organismosFront = new
           {
            tipoOrganismo = TipoOrganismoExtensions.GetNombre(this.TipoOrganismo),
            nombreOrganismo = this.Nombre,
            };

            return organismosFront;
        }
        
    }
}