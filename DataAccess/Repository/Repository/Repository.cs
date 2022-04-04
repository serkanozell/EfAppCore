using DataAccess.Add;
using DataAccess.Delete;
using DataAccess.Select;
using DataAccess.Update;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Repository
{
    public class Repository<TEntity> :
        IAddableRepository<TEntity>, IDeletableRepository<TEntity>,
        ISelectableRepository<TEntity>, IUpdatableRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _table;
        public Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();

        }
        public void Delete(int id)
        {
            _table.Remove(_table.Find(id));
        }
        public void Add(TEntity entity)
        {
            //var addedEntity = _context.Entry(entity);
            //addedEntity.State = EntityState.Added;
            _table.Add(entity);
        }
        public void SoftDelete(TEntity entity)
        {
            entity.GetType().GetProperty("IsActive").SetValue(entity, false);
            Update(entity);
        }
        public void Update(TEntity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            //return _table.Find(condition);
            return _context.Set<TEntity>().SingleOrDefault(condition);
        }

        public  List<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null)
        {
            //if (condition==null)
            //{
            //    return await _context.Set<TEntity>().ToListAsync();
            //}
            return condition == null
                ?  _context.Set<TEntity>().ToList()
                :  _context.Set<TEntity>().Where(condition).ToList();
            //return _table.Where(condition).ToList();
        }

        public TEntity GetById(int id)
        {
            return _table.Find(id);
        }
    }
}
