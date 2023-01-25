using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {
        protected readonly DBContext _Context;

        public DALGenericoImpl(DBContext context)
        {
            _Context = context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _ = _Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _Context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity? Get(int id)
        {
            try
            {
                return _Context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TEntity>? GetAll()
        {
            try
            {
                return _Context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _ = _Context.Set<TEntity>().Attach(entity);
                _ = _Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _Context.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}