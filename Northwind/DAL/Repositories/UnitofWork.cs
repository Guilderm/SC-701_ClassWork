using DAL.Interfaces;

using Entities;

namespace DAL.Repositories;

public class UnitOfWork<T> : IUnitOfWork where T : class
{
    private readonly DBContext _DBcontext;

    public IGenericRepository<T> genericRepository;
    public ICategoryRep category { get; private set; }

    public UnitOfWork(DBContext _context)
    {
        _DBcontext = _context;
        genericRepository = new GenericRepository<T>(_DBcontext);
        category = new CategoryRep(_context);
    }

    public bool Complete()
    {
        try
        {
            _ = _DBcontext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _ = e.Message;
            return false;
        }
    }

    public void Dispose() => _DBcontext.Dispose();
}
