using AutoMapper;

namespace BackEnd.Helpers;

public class AutoMapperConfiguration
	{
	var configuration = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Foo, FooDto>();
		cfg.CreateMap<Bar, BarDto>();
	});
	}
