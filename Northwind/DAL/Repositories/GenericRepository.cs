using DAL.Interfaces;

using Entities;

using Microsoft.EntityFrameworkCore;

using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly DBContext _DBContext;

    public GenericRepository(DBContext DBContex)
    {
        _DBContext = DBContex;
    }

    public bool Add(TEntity entity)
    {
        try
        {
            _ = _DBContext.Set<TEntity>().Add(entity);
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
            _DBContext.Set<TEntity>().AddRange(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            return _DBContext.Set<TEntity>().Where(predicate);
        }
        catch (Exception)
        {
            return Enumerable.Empty<TEntity>();
        }
    }

    public TEntity Get(int id)
    {
        try
        {
            TEntity? entity = _DBContext.Set<TEntity>().Find(id);
            return entity ?? throw new ObjectNotFoundException($"Entity with id {id} not found.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving entity with id {id}: {ex.Message}");
        }
    }

    public IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _DBContext.Set<TEntity>().ToList();
        }
        catch (Exception)
        {
            return Enumerable.Empty<TEntity>();
        }
    }

    public bool Remove(TEntity entity)
    {
        try
        {
            _ = _DBContext.Set<TEntity>().Attach(entity);
            _ = _DBContext.Set<TEntity>().Remove(entity);
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
            _DBContext.Set<TEntity>().RemoveRange(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            TEntity? entity = _DBContext.Set<TEntity>().SingleOrDefault(predicate);
            return entity == null ? throw new ObjectNotFoundException($"Entity with id {predicate} not found.") : entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving entity with id {predicate}: {ex.Message}");
        }
    }

    public bool Update(TEntity entity)
    {
        try
        {
            _DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}