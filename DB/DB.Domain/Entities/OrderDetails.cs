namespace DB.Domain.Entities;

public class OrderDetails
{
	public int Id { get; set; }
	public DateTime Start { get; set; }
	public DateTime End { get; set; }
	public double TotalPrice { get; set; }
	public bool Closed { get; set; }

	//user
	public string UserId { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }

	//car
	public int CarId { get; set; }
	public string Model { get; set; }
	public string RegistrationNumber { get; set; }
	public double Price { get; set; }
	public double RentPrice { get; set; }
	public int ManufactureYear { get; set; }
	public int BrandId { get; set; }
	public string? BrandName { get; set; }
	public int ClassId { get; set; }
	public string? ClassName { get; set; }
	public int BodytypeId { get; set; }
	public string? BodytypeName { get; set; }
}
