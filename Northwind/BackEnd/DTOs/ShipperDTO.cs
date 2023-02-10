using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class ShipperDTO : IDTO
	{
	public int categoryId { get; set; }
	[Required]
	public string CategoryName { get; set; } = null!;
	public string Description { get; set; } = null!;
	}