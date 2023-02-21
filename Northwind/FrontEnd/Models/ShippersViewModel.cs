namespace FrontEnd.Models;

public class ShippersViewModel
{
	public int ShipperId { get; set; }

	public string CompanyName { get; set; } = null!;

	public string Phone { get; set; }

	public ICollection<OrderModel> Orders { get; set; }
}