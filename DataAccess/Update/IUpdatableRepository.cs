using DataAccess.Repository.IRepo;
using Entity;

namespace DataAccess.Update
{
    public interface IUpdatableRepository<T> : IRepository<T> where T : class, IEntity
    {
        void Update(T entity);
    }
}
