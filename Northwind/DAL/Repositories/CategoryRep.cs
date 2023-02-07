using DAL.Interfaces;

using Entities;

namespace DAL.Repositories;

public class CategoryRep : GenericRepository<Category>, ICategoryRep
	{

	public CategoryRep(DBContext DBContext) : base(DBContext)
		{
		}
	}
