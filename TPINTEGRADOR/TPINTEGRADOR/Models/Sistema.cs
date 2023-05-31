
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

        public void AgregarOrganismo(Organismo organismo)
        {
            Organismos.Add(organismo);
        }
    }
}