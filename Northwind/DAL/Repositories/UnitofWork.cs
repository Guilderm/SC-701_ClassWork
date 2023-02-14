using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
	{
	private readonly DBContext _DBcontext;
	private bool disposed = false;
	private readonly ILogger<UnitOfWork> _logger;

	public UnitOfWork(ILogger<UnitOfWork> logger)
		{
		_DBcontext = new DBContext();
		_logger = logger;
		}

	public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class => new GenericRepository<TEntity>(_DBcontext);

	public void SaveChanges()
		{
		try
			{
			int rowsAffected = _DBcontext.SaveChanges();
			_logger.LogInformation("", $"EF affected {rowsAffected} rows when saving changes.");
			}
		catch (DbUpdateException ex)
			{
			_logger.LogError(ex, "We got a DB Update Exception");
			}
		catch (Exception ex)
			{
			_logger.LogError(ex, "We got a Exception");
			}
		}

	protected virtual void Dispose(bool disposing)
		{
		if (!disposed)
			{
			if (disposing)
				{
				_DBcontext.Dispose();
				}
			}
		disposed = true;
		}

	public void Dispose()
		{
		Dispose(true);
		GC.SuppressFinalize(this);
		}
	}