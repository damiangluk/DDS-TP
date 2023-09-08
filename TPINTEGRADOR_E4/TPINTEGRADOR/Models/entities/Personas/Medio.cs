
namespace TPINTEGRADOR.Models
{
    public abstract class Medio : Identidad
    {
        #region constructores
        public Medio() { }
        public Medio(string contacto) 
        {
            Contacto = contacto;
        }
        #endregion

        #region propiedades
        public string Contacto { get; set; }
        #endregion

        #region metodos
        public abstract void Notificar(string mensaje, Persona persona);
        #endregion
    }
}
