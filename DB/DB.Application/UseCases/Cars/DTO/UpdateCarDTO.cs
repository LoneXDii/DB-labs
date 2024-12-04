namespace DB.Application.UseCases.Cars.DTO;

public class UpdateCarDTO
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public double Price { get; set; }
    public double RentPrice { get; set; }
    public int ManufactureYear { get; set; }
    public int BrandId { get; set; }
    public int ClassId { get; set; }
    public int BodytypeId { get; set; }
}
