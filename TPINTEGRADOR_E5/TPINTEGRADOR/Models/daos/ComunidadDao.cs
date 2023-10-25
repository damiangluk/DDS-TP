using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class ComunidadDao : GenericDao<Comunidad>
    {
        public List<object> GetAllByUser(Usuario user)
        {
            return context.Localizaciones.Select(t => new
            {
                Id = t.Id,
                Text = t.Nombre
            }).ToList<object>();
        }
    }
}
