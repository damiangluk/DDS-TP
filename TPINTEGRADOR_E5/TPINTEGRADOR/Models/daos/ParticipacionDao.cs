using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class ParticipacionDao : GenericDao<Participacion>
    {
        public List<Participacion> GetAllByPerson(Persona persona)
        {
            return context.Participaciones.Where(p =>
                p.PersonaId == persona.Id).ToList();
        }
    }
}
