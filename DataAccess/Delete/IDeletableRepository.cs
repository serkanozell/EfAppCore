using DataAccess.Repository.IRepo;
using Entity;

namespace DataAccess.Delete
{
    public interface IDeletableRepository<T> : IRepository<T> where T : class, IEntity
    {
       // void Delete(int id);   bunu yapmak için yeni unit of work ve yeni repository sistemi gerekli !!
        void SoftDelete(T entity);
    }
}
