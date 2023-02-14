using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
	protected readonly DBContext _DBContext;
	private readonly DbSet<TEntity> _dbSet;
	//private readonly ILogger _logger;

	public GenericRepository(DBContext DBContex)
		{
		_DBContext = DBContex;
		_dbSet = _DBContext.Set<TEntity>();
		//_logger = Log.ForContext<GenericRepository<TEntity>>();
		}

	public void Insert(TEntity entity) => _dbSet.Add(entity);

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
		TEntity entity = _DBContext.Set<TEntity>().Find(id);

		if (entity == null)
			{
			//_logger.Error($"Entity of type {typeof(TEntity)}, with id {id} not found.");
			}
		return entity;
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
			_DBContext.Set<TEntity>().Attach(entity);
			_DBContext.Set<TEntity>().Remove(entity);
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
			return entity ?? throw new ObjectNotFoundException($"Entity with id {predicate} not found.");
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