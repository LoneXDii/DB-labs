namespace DB.Domain.Entities;

public class Order
{
	public int OrderId { get; set; }
	public DateTime Start { get; set; }
	public DateTime End { get; set; }
	public double TotalPrice { get; set; }
	public bool Closed { get; set; }

	//user
	public string UserId { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }

	public List<Car> Cars { get; set; }
}
