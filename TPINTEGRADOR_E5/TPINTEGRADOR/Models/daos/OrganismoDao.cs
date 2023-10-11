using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class OrganismoDao : GenericDao<Organismo>
    {
        public bool AgregarOrganismo(string[] columns)
        {
            if (columns.Length < 2)
                throw new Exception("Se intento crear un organismo sin informacion");

            TipoOrganismo? tipoOrganismo = TipoOrganismoExtensions.GetType(columns[0].Trim());

            if (!tipoOrganismo.HasValue) return false;
            if (context.Organismos.Any(o => o.Nombre.Equals(columns[1]))) return false;

            Organismo organismo = new Organismo(tipoOrganismo.Value, columns[1].Trim());

            Insert(organismo);

            return true;
        }

        public bool AgregarOrganismo(Organismo organismo)
        {
            if (context.Organismos.Any(o => o.Nombre.Equals(organismo.Nombre)))
                return false;

            Insert(organismo);

            return true;
        }
    }
}
