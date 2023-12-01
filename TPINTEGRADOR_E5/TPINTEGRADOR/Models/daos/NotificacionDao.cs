using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class NotificacionDao : GenericDao<Notificacion>
    {
        public List<Notificacion> GetAllByPerson(Persona persona)
        {
            var from = DateTime.Now.AddDays(-1);
            return context.Notificaciones.Where(p =>
                p.PersonaId == persona.Id && p.Fecha > from).ToList();
        }
    }
}
