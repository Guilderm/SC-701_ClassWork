using DAL.Interfaces;

using Entities;

namespace DAL.Repositories;

public class UnitOfWork<T> : IDisposable where T : class
{
    private readonly DBContext _DBcontext;
    //public IGenericRepositories<Queja> quejaDAL;
    //public IGenericRepositories<TablaGeneral> tablaDAL;
    public IGenericRepository<T> genericDAL;

    public UnitOfWork(DBContext _context)
    {
        _DBcontext = _context;
        genericDAL = new GenericRepository<T>(_DBcontext);
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
