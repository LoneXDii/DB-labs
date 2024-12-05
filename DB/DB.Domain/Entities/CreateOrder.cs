namespace DB.Domain.Entities;

public class CreateOrder
{
    public string UserId { get; set; } = "";
    public DateTime Start {  get; set; } = DateTime.Now;
    public List<int> CarsIds { get; set; } = new();
}
