
namespace TPINTEGRADOR.Models
{
    public class Persona : Identidad
    {
        public Persona(string nombre, string apellido, string correoElectronico, string contrasenia) 
        {
            Nombre = nombre;
            Apellido = apellido;
            CorreoElectronico = correoElectronico;
            Contrasenia = contrasenia;
        }

        public string Nombre;
        public string Apellido;
        public string CorreoElectronico;
        public string Contrasenia;
        //intereses
        //entidadesInteresadas
        //localizacionDeInteres
    }
}
