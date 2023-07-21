namespace TPINTEGRADOR.Models
{
    public sealed class SistemaGeneral
    {
        #region instance
        private static readonly SistemaGeneral instance = new SistemaGeneral();

        private SistemaGeneral() { }

        public static SistemaGeneral GetInstance
        {
            get { return instance; }
        }
        #endregion

        #region properties
        public SistemaServiciosPublicos ServiciosPublicos { get; set; } = SistemaServiciosPublicos.GetInstance;
        public SistemaServicios Servicios { get; set; } = SistemaServicios.GetInstance;
        public SistemaPersonas Personas { get; set; } = SistemaPersonas.GetInstance;
        #endregion
    }
}