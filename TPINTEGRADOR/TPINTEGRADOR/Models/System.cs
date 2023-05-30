
namespace TPINTEGRADOR.Models
{

    public sealed class System
    {
        List<Organismo> Organismos { get; set; } = new List<Organismo>();
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
    }
}