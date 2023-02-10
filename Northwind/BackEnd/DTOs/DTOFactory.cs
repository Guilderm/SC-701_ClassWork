namespace BackEnd.DTOs;

public static class DTOFactory
	{
	public static object GetDTO<TModel>(TModel model) where TModel : class
		{

		switch (model)
			{
			case CategoryDTO:
				return new CategoryDTO();
			case ShipperDTO:
				return new ShipperDTO();
			default:
				throw new ArgumentException("Invalid DTO type.");
			}
		}
	}