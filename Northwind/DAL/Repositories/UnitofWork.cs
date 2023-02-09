using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
	{
	private readonly DBContext _DBcontext;
	private bool disposed = false;

	//This will generate a Repository for Catergory that wil only be based on the Generic repository.
	public IGenericRepository<Category> _category;

	//This will generate a Custom repository that inherits from the Generic Repository for shipper.
	public IShipperRepository _shipper;

	public UnitOfWork()
		{
		_DBcontext = new DBContext();
		_category = new GenericRepository<Category>(_DBcontext);
		_shipper = new ShipperRepository(_DBcontext);
		}

	public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_DBcontext);
	public IShipperRepository Shipper => _shipper ??= new ShipperRepository(_DBcontext);





	/// <summary>
	/// ///////////////////////////////////////////////////////////////////////////////////
	/// </summary>
	/// 


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