using Entities;

namespace DAL.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IRepository<Category> category { get; }
}
