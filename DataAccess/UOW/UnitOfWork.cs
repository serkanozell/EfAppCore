using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(EfAppContext context)
        {
            _context = context;
            Products = new EfProductRepository(context);
            Categories = new EfCategoryRepository(context);
        }
        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
