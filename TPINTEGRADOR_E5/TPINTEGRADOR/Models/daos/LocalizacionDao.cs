using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class LocalizacionDao : GenericDao<Localizacion>
    {
        public List<object> GetAllFromDropdown()
        {
            return context.Localizaciones.Select(t => new
            {
                Id = t.Id,
                Text = t.Nombre
            }).ToList<object>();
        }
    }
}
