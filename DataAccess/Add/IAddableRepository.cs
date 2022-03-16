using DataAccess.Repository.IRepo;
using Entity;
using System.Threading.Tasks;

namespace DataAccess.Add
{
    public interface IAddableRepository<T> : IRepository<T> where T : class, IEntity
    {
        void Add(T entity);
    }
}
