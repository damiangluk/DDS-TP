using Microsoft.AspNetCore.Identity;

namespace TPINTEGRADOR.Models
{
    public class ServicioAgrupado : SuperServicio
    {
        public ServicioAgrupado(List<Servicio> servicios, string nombre) : base(nombre)
        {
            Servicios = servicios;
        }

        public List<Servicio> Servicios;
    }
}
