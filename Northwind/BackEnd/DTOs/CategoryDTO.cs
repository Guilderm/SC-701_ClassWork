using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class CategoryDTO
	{
	public int CategoryId { get; set; }
	[Required]
	public string CategoryName { get; set; } = null!;
	public string? Description { get; set; }
	}

