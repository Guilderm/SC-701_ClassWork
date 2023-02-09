using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<T> : ControllerBase where T : class
	{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IGenericRepository<T> _Repository;

	public BaseController()
		{
		_unitOfWork = new UnitOfWork();
		_Repository = _unitOfWork.GetRepository<T>();
		}
	}