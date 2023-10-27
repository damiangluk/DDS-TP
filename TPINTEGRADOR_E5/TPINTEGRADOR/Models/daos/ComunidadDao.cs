using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class ComunidadDao : GenericDao<Comunidad>
    {
        public List<Comunidad> GetAllByUser(Persona persona)
        {
            return context.Participaciones.Where(p => 
                p.PersonaId == persona.Id).ToList().Select(p => p.Comunidad).ToList();
        }


    }
}
