using DAL.Interfaces;

using Entities;

using System.Linq.Expressions;

namespace DAL.Repositories;

public class CategoryRepository : ICategoryRepository
	{
	private readonly DBContext _DBcontext;

	public CategoryRepository(DBContext DBContext)
		{
		_DBcontext=DBContext;
		}

	public bool Add(Category entity)
		{
		try
			{
			using (UnitOfWork<Category> UnitOfWork = new(_DBcontext))
				{
				_=UnitOfWork.genericRepository.Add(entity);
				_=UnitOfWork.Complete();
				}
			return true;
			}
		catch (Exception)
			{
			return false;
			}
		}

	public void AddRange(IEnumerable<Category> entities) => throw new NotImplementedException();

	public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate) => throw new NotImplementedException();

	public Category Get(int id)
		{
		Category category;
		using (UnitOfWork<Category> UnitOfWork = new(_DBcontext))
			{
			category=UnitOfWork.genericRepository.Get(id);
			}
		return category;
		}

	public IEnumerable<Category> GetAll()
		{
		try
			{
			IEnumerable<Category> categories;
			using (UnitOfWork<Category> UnitOfWork = new(_DBcontext))
				{
				categories=UnitOfWork.genericRepository.GetAll();
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
			using UnitOfWork<Category> UnitOfWork = new(_DBcontext);
			_=UnitOfWork.genericRepository.Remove(entity);
			result=UnitOfWork.Complete();
			}
		catch (Exception)
			{
			result=false;
			}
		return result;
		}

	public void RemoveRange(IEnumerable<Category> entities) => throw new NotImplementedException();

	public Category SingleOrDefault(Expression<Func<Category, bool>> predicate) => throw new NotImplementedException();

	public bool Update(Category entity)
		{
		bool result = false;

		try
			{
			using UnitOfWork<Category> unidad = new(_DBcontext);
			_=unidad.genericRepository.Update(entity);
			result=unidad.Complete();
			}
		catch (Exception)
			{
			return false;
			}
		return result;
		}
	}
