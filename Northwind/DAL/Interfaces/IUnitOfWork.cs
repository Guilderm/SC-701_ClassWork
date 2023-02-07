using Entities;

namespace DAL.Interfaces;
public interface IUnitOfWork : IDisposable
	{
	IRepository<Category> Category { get; }
	IRepository<Shipper> Shipper { get; }
	}
