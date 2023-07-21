
namespace TPINTEGRADOR.Models
{
    public class Participacion : Identidad
    {
        public Participacion(Persona persona, Comunidad comunidad, Rol rol)//, Medio medio)
        {
            Persona = persona;
            Comunidad = comunidad;
            Rol = rol;
            //Medio = medio;
        }

        public Persona Persona;
        public Comunidad Comunidad;
        public Rol Rol;
        //public Medio Contrasenia;
        //intereses
        //entidadesInteresadas
        //localizacionDeInteres
    }
}