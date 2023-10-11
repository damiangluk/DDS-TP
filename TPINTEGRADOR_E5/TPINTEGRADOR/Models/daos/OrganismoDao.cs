using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public static class OrganismoDao
    {
        private static DBContext context = DBContext.CreateDbContext();

        public static bool AgregarOrganismo(string[] columns)
        {
            if (columns.Length < 2)
                throw new Exception("Se intento crear un organismo sin informacion");

            TipoOrganismo? tipoOrganismo = TipoOrganismoExtensions.GetType(columns[0].Trim());

            if (!tipoOrganismo.HasValue) return false;
            if (context.Organismos.ToList().Any(o => o.Nombre.Equals(columns[1]))) return false;

            Organismo organismo = new Organismo(tipoOrganismo.Value, columns[1].Trim());

            context.Organismos.ToList().Add(organismo);

            return true;
        }

        public static bool AgregarOrganismo(Organismo organismo)
        {
            if (context.Organismos.ToList().Any(o => o.Nombre.Equals(organismo.Nombre)))
                return false;

            context.Organismos.ToList().Add(organismo);

            return true;
        }
    }
}
