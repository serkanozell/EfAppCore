using DataAccess.Abstract;
using System;

namespace DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IUserRepository User { get; }
        void SaveChanges();
    }
}
