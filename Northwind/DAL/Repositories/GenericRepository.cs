using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Entity.Core;
using System.Linq.Expressions;
using DbContext = Entities.DbContext;

namespace DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
	protected readonly DbContext DbContext;
	private readonly DbSet<TEntity> _dbSet;
	private readonly ILogger<GenericRepository<TEntity>> _logger;

	public GenericRepository(DbContext dbContex)
		{
		DbContext = dbContex;
		_dbSet = DbContext.Set<TEntity>();
		_logger = new LoggerFactory().CreateLogger<GenericRepository<TEntity>>();
		}

	public void Insert(TEntity entity) => _dbSet.Add(entity);

	public void AddRange(IEnumerable<TEntity> entities) => DbContext.Set<TEntity>().AddRange(entities);

	public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
		try
			{
			return DbContext.Set<TEntity>().Where(predicate);
			}
		catch (Exception)
			{

			return Enumerable.Empty<TEntity>();
			}
		}

	public TEntity Get(int id)
		{
		_logger.LogCritical($"will look for Entity with id {id} not found.");
		TEntity entity = DbContext.Set<TEntity>().Find(id);

		if (entity == null)
			{
			_logger.LogError($"Entity of type {typeof(TEntity)}, with id {id} not found.");
			}
		return entity;
		}

	public IEnumerable<TEntity> GetAll()
		{
		try
			{
			return DbContext.Set<TEntity>().ToList();
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
			DbContext.Set<TEntity>().Attach(entity);
			DbContext.Set<TEntity>().Remove(entity);
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
			DbContext.Set<TEntity>().RemoveRange(entities);
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
			TEntity? entity = DbContext.Set<TEntity>().SingleOrDefault(predicate);
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
			DbContext.Entry(entity).State = EntityState.Modified;
			return true;
			}
		catch (Exception)
			{
			return false;
			}
		}
	}



// Path: DAL\Interfaces\IGenericRepository.cs
//