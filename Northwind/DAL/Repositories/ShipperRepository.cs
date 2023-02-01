using DAL.Interfaces;

using Entities;

using System.Linq.Expressions;

namespace DAL.Repositories;

public class ShipperRepository : IShipperRepository
{
    private readonly DBContext _DBcontext;

    public ShipperRepository(DBContext DBContext)
    {
        _DBcontext = DBContext;
    }

    public bool Add(Shipper entity)
    {
        try
        {
            using (UnitOfWork<Shipper> UnitOfWork = new(_DBcontext))
            {
                _ = UnitOfWork.genericDAL.Add(entity);
                _ = UnitOfWork.Complete();
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void AddRange(IEnumerable<Shipper> entities) => throw new NotImplementedException();

    public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate) => throw new NotImplementedException();

    public Shipper Get(int id)
    {
        Shipper Shipper;
        using (UnitOfWork<Shipper> UnitOfWork = new(_DBcontext))
        {
            Shipper = UnitOfWork.genericDAL.Get(id);
        }
        return Shipper;
    }

    public IEnumerable<Shipper> GetAll()
    {
        try
        {
            IEnumerable<Shipper> categories;
            using (UnitOfWork<Shipper> UnitOfWork = new(_DBcontext))
            {
                categories = UnitOfWork.genericDAL.GetAll();
            }
            return categories;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Remove(Shipper entity)
    {
        bool result = false;
        try
        {
            using UnitOfWork<Shipper> UnitOfWork = new(_DBcontext);
            _ = UnitOfWork.genericDAL.Remove(entity);
            result = UnitOfWork.Complete();
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }

    public void RemoveRange(IEnumerable<Shipper> entities) => throw new NotImplementedException();

    public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate) => throw new NotImplementedException();

    public bool Update(Shipper entity)
    {
        bool result = false;

        try
        {
            using UnitOfWork<Shipper> unidad = new(_DBcontext);
            _ = unidad.genericDAL.Update(entity);
            result = unidad.Complete();
        }
        catch (Exception)
        {
            return false;
        }
        return result;
    }
}