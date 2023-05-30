
namespace TPINTEGRADOR.Models
{
    public enum TipoOrganismo
    {
        EMPRESA,
        ORGANISMODECONTROL
    }

    public static class TipoOrganismoExtensions
    {
        public static TipoOrganismo? GetType(string type)
        {
            switch (type)
            {
                case "EMPRESA":
                    return TipoOrganismo.EMPRESA;
                case "ORGANISMODECONTROL":
                    return TipoOrganismo.ORGANISMODECONTROL;
                default:
                    return null;

            }
        }
    }
}
