using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public sealed class ShipperDto
{
	public int ShipperId { get; set; }

	[Required] public string CompanyName { get; set; } = null!;

	public string? Phone { get; set; }

	public ICollection<OrderDto>? Orders { get; set; }
}