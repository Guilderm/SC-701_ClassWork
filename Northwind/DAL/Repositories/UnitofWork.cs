using DAL.Interfaces;
using Entities;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
   {
   private readonly DBContext _DBcontext;

   public IGenericRepository<Category> _category;
   public IGenericRepository<Shipper> _shipper;

   public UnitOfWork(DBContext _context)
      {
      _DBcontext=_context;
      _category=new GenericRepository<Category>(_DBcontext);
      _shipper=new GenericRepository<Shipper>(_DBcontext);
      }

   public IGenericRepository<Category> Category => _category??=new GenericRepository<Category>(_DBcontext);
   public IGenericRepository<Shipper> Shipper => _shipper??=new GenericRepository<Shipper>(_DBcontext);

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
