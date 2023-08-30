
namespace TPINTEGRADOR.Models
{
    public abstract class Medio : Identidad
    {
        public Medio() { }
        public Medio(string contacto) 
        {
            Contacto = contacto;
        }

        public string Contacto { get; set; }

        public abstract void Notificar(string mensaje, Persona persona);
    }
}
