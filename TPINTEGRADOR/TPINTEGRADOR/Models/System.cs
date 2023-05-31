
namespace TPINTEGRADOR.Models
{

    public sealed class System
    {
        public List<Organismo> Organismos = new List<Organismo>();
        private static readonly System instance = new System();

        private System() { }

        public static System GetInstance
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