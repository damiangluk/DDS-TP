namespace TPINTEGRADOR.Models
{

    public sealed class SistemaServicios
    {
        #region instance
        private static readonly SistemaServicios instance = new SistemaServicios();

        private SistemaServicios() { }

        public static SistemaServicios GetInstance
        {
            get { return instance; }
        }
        #endregion
    }
}