using DAL.Interfaces;
using Entities;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
   {
   private readonly DBContext _DBcontext;

   public IGenericRepository<Category> _category;
   public IShipperRepository _shipper;

   public UnitOfWork()
      {
      _DBcontext = new DBContext();
      _category = new GenericRepository<Category>(_DBcontext);
      _shipper = new ShipperRepository(_DBcontext);
      }

   public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_DBcontext);
   public IShipperRepository Shipper => _shipper ??= new ShipperRepository(_DBcontext);

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
