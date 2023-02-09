using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<TEntity> : ControllerBase where TEntity : class
	{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IGenericRepository<TEntity> _Repository;
	protected readonly IMapper _Mapper;

	public BaseController(IUnitOfWork unitOfWork, IMapper Mapper)
		{
		_unitOfWork = unitOfWork;
		_Repository = _unitOfWork.GetRepository<TEntity>();
		_Mapper = Mapper;
		}
	}