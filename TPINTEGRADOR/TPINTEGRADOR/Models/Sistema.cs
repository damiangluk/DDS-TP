
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPINTEGRADOR.Models
{

    public sealed class Sistema
    {
        public List<Organismo> Organismos { get; set; } = new List<Organismo>();
        private static readonly Sistema instance = new Sistema();

        private Sistema() { }

        public static Sistema GetInstance
        {
            get
            {
                return instance;
            }
        }
        // OBTENER SISTEMA: System s = System.GetInstance;

        public bool AgregarOrganismo(string[] columns)
        {
            if (columns.Length < 2)
                throw new Exception("Se intento crear un organismo sin informacion");

            TipoOrganismo? tipoOrganismo = TipoOrganismoExtensions.GetType(columns[0].Trim());

            if (!tipoOrganismo.HasValue) return false;
            if (Organismos.Any(o => o.Nombre.Equals(columns[1]))) return false;

            Organismo organismo = new Organismo(tipoOrganismo.Value, columns[1].Trim());

            Organismos.Add(organismo);

            return true;
        }

        public bool AgregarOrganismo(Organismo organismo)
        {
            if(Organismos.Any(o => o.Nombre.Equals(organismo.Nombre)))
                return false;

            Organismos.Add(organismo);

            return true;
        }
    }
}