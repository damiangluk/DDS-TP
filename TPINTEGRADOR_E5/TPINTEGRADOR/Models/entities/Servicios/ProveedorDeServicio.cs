namespace TPINTEGRADOR.Models
{
    public class ProveedorDeServicio : Identidad
    {
        #region constructores
        public ProveedorDeServicio() { }
        public ProveedorDeServicio(string nombre)
        {
            Nombre = nombre;
        }
        #endregion

        #region propiedades
        public string Nombre { get; set; }

        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<SuperServicio> SuperServicio { get; set; }
        #endregion
    }
}