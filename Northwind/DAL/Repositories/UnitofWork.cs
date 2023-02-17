using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DbContext = Entities.DbContext;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
	{
	private readonly DbContext _dBcontext;
	private bool _disposed = false;
	private readonly ILogger<UnitOfWork> _logger;

	public UnitOfWork(ILogger<UnitOfWork> logger)
		{
		_dBcontext = new DbContext();
		_logger = logger;
		}

	public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class => new GenericRepository<TEntity>(_dBcontext);

	public void SaveChanges()
		{
		try
			{
			int rowsAffected = _dBcontext.SaveChanges();
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
		if (!_disposed)
			{
			if (disposing)
				{
				_dBcontext.Dispose();
				}
			}
		_disposed = true;
		}

	public void Dispose()
		{
		Dispose(true);
		GC.SuppressFinalize(this);
		}
	}