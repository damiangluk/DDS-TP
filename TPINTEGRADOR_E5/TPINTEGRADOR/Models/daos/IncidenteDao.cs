using Microsoft.EntityFrameworkCore;
using TPINTEGRADOR.Models.daos.auxClasses;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class IncidenteDao : GenericDao<Incidente>
    {
        public void CrearIncidente(Incidente incidente, int idServicio)
        {
            SuperServicio servicio = DataFactory.ServicioDao.GetById(idServicio);
            incidente.Servicio = servicio;
            Insert(incidente);
            servicio.Comunidades.ToList().ForEach(c => c.NotificarMiembros(incidente));
        }

        public void CerrarIncidente(int idIncidente)
        {
            Incidente incidente = GetById(idIncidente);
            incidente.FechaCierre = DateTime.Now;
            Update(incidente);
        }

        public List<Incidente> ConsultarIncidentePorEstado(bool? estado)
        {
            if (!estado.HasValue)
                return GetAll();
            return context.Incidentes.AsEnumerable().Where(i => i.EstaAbierto() == estado).ToList();
        }

        public List<Incidente> FindCloseWeeklyWithoutToday()
        {
            var from = DateTime.Now.AddDays(-7);
            var to = DateTime.Now.AddDays(-1);
            return context.Incidentes.Where(i => (i.FechaCierre != null || i.FechaApertura < to) && i.FechaApertura >= from).ToList();
        }

        public List<Incidente> FindCloseWeekly()
        {
            var from = DateTime.Now.AddDays(-7);
            return context.Incidentes.Where(i => i.FechaCierre != null && i.FechaApertura >= from).ToList();
        }

        public List<Incidente> FindWithWeeklyImpact()
        {
            var from = DateTime.Now.AddDays(-7);
            return context.Incidentes.Where(i => i.FechaCierre == null || i.FechaApertura >= from).ToList();
        }
    }
}
