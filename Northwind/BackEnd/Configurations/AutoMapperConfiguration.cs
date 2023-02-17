using AutoMapper;
using BackEnd.DTOs;
using Entities;

namespace BackEnd.Configurations;

public class AutoMapperConfiguration : Profile
	{
	public AutoMapperConfiguration()
		{
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<Shipper, ShipperDto>().ReverseMap();
		}
	}