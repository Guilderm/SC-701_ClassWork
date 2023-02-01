using DAL.Interfaces;

using Entities;

namespace DAL.Repositories;

public class UnitOfWork<T> : IDisposable where T : class
{
    private readonly DBContext _context;
    //public IGenericRepositories<Queja> quejaDAL;
    //public IGenericRepositories<TablaGeneral> tablaDAL;
    public IGenericRepositories<T> genericDAL;

    public UnitOfWork(DBContext _context)
    {
        this._context = _context;
        genericDAL = new GenericRepositories<T>(this._context);

    }

    public bool Complete()
    {
        try
        {
            _ = _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _ = e.Message;
            return false;
        }
    }

    public void Dispose() => _context.Dispose();
}
