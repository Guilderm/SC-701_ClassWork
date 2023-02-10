using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
	{
	private readonly DBContext _DBcontext;
	private bool disposed = false;

	public UnitOfWork()
		{
		_DBcontext = new DBContext();
		}

	public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class => new GenericRepository<TEntity>(_DBcontext);

	public void SaveChanges()
		{
		try
			{
			int rowsAffected = _DBcontext.SaveChanges();
			Console.WriteLine($"EF affected {rowsAffected} rows when saving changes.");
			}
		catch (DbUpdateException ex)
			{
			// Log the exception
			Console.WriteLine(ex.Message);
			}
		catch (Exception ex)
			{
			// Log the exception
			Console.WriteLine(ex.Message);
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