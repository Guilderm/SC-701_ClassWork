﻿using Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class ShipperDto
	{
	public int ShipperId { get; set; }
	[Required]
	public string CompanyName { get; set; } = null!;
	public string? Phone { get; set; }
	public virtual ICollection<Order>? Orders { get; set; }
	}