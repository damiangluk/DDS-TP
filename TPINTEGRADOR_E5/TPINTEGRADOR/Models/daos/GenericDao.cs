using TPINTEGRADOR.Models.daos.auxClasses;
using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class GenericDao<TDaotype> : IGenericDao<TDaotype> where TDaotype : Identidad
    {
        protected DBContext context = DBContext.CreateDbContext();

        public TDaotype GetById(object id)
        {
            return context.Set<TDaotype>().FirstOrDefault(e => e.Id.Equals(id));
        }

        public List<TDaotype> GetAll()
        {
            return context.Set<TDaotype>().ToList();
        }

        public virtual void Insert(TDaotype obj)
        {
            try
            {
                context.Set<TDaotype>().Update(obj); //Add(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TDaotype entity)
        {
            context.Set<TDaotype>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(TDaotype entity)
        {
            context.Set<TDaotype>().Remove(entity);
            context.SaveChanges();
        }
    }
}
