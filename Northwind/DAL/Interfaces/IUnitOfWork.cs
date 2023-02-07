using Entities;

namespace DAL.Interfaces;
public interface IUnitOfWork : IDisposable
	{
	IGenericRepository<Category> Category { get; }
	IGenericRepository<Shipper> Shipper { get; }
	}
