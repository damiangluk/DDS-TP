namespace TPINTEGRADOR.Models.daos.auxClasses
{
    public interface IGenericDao<TDaotype> where TDaotype : Identidad
    {
        TDaotype GetById(object id);
        List<TDaotype> GetAll();
        void Insert(TDaotype entity);
        void Update(TDaotype entity);
        void Delete(TDaotype entity);
    }
}