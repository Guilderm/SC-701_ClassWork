﻿using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class CategoryDALImpl : ICategoryDAL
    {
        private readonly DBContext _context;


        public CategoryDALImpl()
        {
            _context = new DBContext();
        }

        public CategoryDALImpl(DBContext _Context)
        {
            _context = _Context;
        }

        public bool Add(Category entity)
        {
            try
            {
                using (UnitofWork<Category> unidad = new(_context))
                {
                    _ = unidad.genericDAL.Add(entity);
                    _ = unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            Category category;
            using (UnitofWork<Category> unidad = new(_context))
            {

                category = unidad.genericDAL.Get(id);
            }
            return category;

        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                IEnumerable<Category> categories;
                using (UnitofWork<Category> unidad = new(_context))
                {
                    categories = unidad.genericDAL.GetAll();
                }
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Category entity)
        {
            bool result = false;
            try
            {
                using UnitofWork<Category> unidad = new(_context);
                _ = unidad.genericDAL.Remove(entity);
                result = unidad.Complete();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category SingleOrDefault(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            bool result = false;

            try
            {
                using UnitofWork<Category> unidad = new(_context);
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
}
