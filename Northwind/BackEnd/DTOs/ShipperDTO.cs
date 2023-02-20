using System.ComponentModel.DataAnnotations;
using Entities;

namespace BackEnd.DTOs;

public sealed class ShipperDto
{
	public int ShipperId { get; set; }

	[Required] public string CompanyName { get; set; } = null!;

	public string? Phone { get; set; }
	public ICollection<Order>? Orders { get; set; }
}