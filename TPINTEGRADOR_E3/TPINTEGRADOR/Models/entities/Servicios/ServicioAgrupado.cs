using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class ServicioAgrupado : SuperServicio
    {
        public ServicioAgrupado(List<Servicio> servicios, string nombre, Entidad entidad) : base(nombre, entidad)
        {
            Servicios = servicios;
        }

        public List<Servicio> Servicios;
    }
}
