using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class CategoryDto
	{
	public int CategoryId { get; set; }
	[Required]
	public string CategoryName { get; set; } = null!;
	public string Description { get; set; } = null!;
	}