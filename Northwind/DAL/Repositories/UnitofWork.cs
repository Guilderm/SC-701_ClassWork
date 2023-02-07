using DAL.Interfaces;

using Entities;

namespace DAL.Repositories;

public class UnitOfWork<TEntity> : IUnitOfWork where TEntity : class
    {
    private readonly DBContext _DBcontext;

    public IGenericRepository<TEntity> genericRepository;
    public IRepository<Category> _category;
    public IRepository<Shipper> _shipper;

    public UnitOfWork(DBContext _context)
        {
        _DBcontext=_context;
        genericRepository=new GenericRepository<TEntity>(_DBcontext);
        }

    public IRepository<Category> Category => _category??=new Repository<Category>(_DBcontext);
    public IRepository<Shipper> Shipper => _shipper??=new Repository<Shipper>(_DBcontext);

    public bool Complete()
        {
        try
            {
            _=_DBcontext.SaveChanges();
            return true;
            }
        catch (Exception e)
            {
            _=e.Message;
            return false;
            }
        }

    public void Dispose() => _DBcontext.Dispose();
    }
