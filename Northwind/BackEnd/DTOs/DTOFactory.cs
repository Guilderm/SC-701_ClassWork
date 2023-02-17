namespace BackEnd.DTOs;

public static class DtoFactory
	{
	public static object GetDto<TModel>(TModel model) where TModel : class
		{

		switch (model)
			{
			case CategoryDto:
				return new CategoryDto();
			case ShipperDto:
				return new ShipperDto();
			default:
				throw new ArgumentException("Invalid DTO type.");
			}
		}
	}