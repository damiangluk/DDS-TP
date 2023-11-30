using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class NotificacionDao : GenericDao<Notificacion>
    {
        public List<Notificacion> GetAllByPerson(Persona persona)
        {
            return context.Notificaciones.Where(p =>
                p.PersonaId == persona.Id && !p.Entregado).ToList();
        }
    }
}
