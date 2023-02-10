using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;

namespace BackEnd.Controllers;

public class ShipperController : BaseController<Category, CategoryDTO>
	{
	public ShipperController(IUnitOfWork unitOfWork, IMapper Mapper) : base(unitOfWork, Mapper)
		{
		}
	}