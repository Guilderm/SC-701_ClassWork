using BackEnd.Models;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<TEntity> : ControllerBase where TEntity : class
	{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IGenericRepository<TEntity> _Repository;

	public BaseController()
		{
		_unitOfWork = new UnitOfWork();
		_Repository = _unitOfWork.GetRepository<TEntity>();
		}

	#region Mappers
	protected virtual CategoryModel? MapEntityToModel(TEntity entity) => null;

	protected virtual TEntity? MapModelToEntity(CategoryModel model) => null;
	#endregion
	}

