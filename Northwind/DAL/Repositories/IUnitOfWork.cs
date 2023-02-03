using DAL.Interfaces;

namespace DAL.Repositories;
public interface IUnitOfWork : IDisposable
{
    ICategoryRep category { get; }
}
