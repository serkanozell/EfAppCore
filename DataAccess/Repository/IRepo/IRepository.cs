using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepo
{
    public interface IRepository<T> where T : class, IEntity
    {
        void SaveChanges();
    }
}
