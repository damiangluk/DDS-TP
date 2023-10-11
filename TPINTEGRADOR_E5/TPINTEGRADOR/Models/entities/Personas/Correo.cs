
namespace TPINTEGRADOR.Models
{
    public class Correo : Medio
    {
        public Correo() { }

        public Correo(string contacto) : base(contacto)
        {

        }

        public override void Notificar(string mensaje, Persona persona)
        {
            // Enviar mail a la PERSONA a la direccion de CONTACTO con el MENSAJE
        }
    }
}
