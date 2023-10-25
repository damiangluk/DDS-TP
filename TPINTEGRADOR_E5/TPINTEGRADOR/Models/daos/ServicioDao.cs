using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class ServicioDao : GenericDao<SuperServicio>
    {
        public List<object> GetAllFromDropdown() {
            return context.SuperServicios.Select(t => new
            {
                Id = t.Id,
                Text = t.Nombre
            }).ToList<object>();
        }
    }
}
