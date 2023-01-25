﻿using DAL.Interfaces;
using Entities;

namespace DAL.Implementations
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private readonly DBContext _context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenerico<T> genericDAL;


        public UnitOfWork(DBContext _context)
        {
            this._context = _context;
            genericDAL = new DALGenericoImpl<T>(this._context);

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


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
