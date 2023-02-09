using Entities;

namespace DAL.Interfaces;
public interface IUnitOfWork : IDisposable
	{
	IGenericRepository<Category> Category { get; }
	IShipperRepository Shipper { get; }

	IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

	void SaveChanges();
	}
