using DataAccess.Repository.IRepo;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Select
{
    public interface ISelectableRepository<T> : IRepository<T> where T : class, IEntity
    {
        T Get(Expression<Func<T, bool>> condition);
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> condition = null);
    }
}
