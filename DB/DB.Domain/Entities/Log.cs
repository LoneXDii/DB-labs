namespace DB.Domain.Entities;

public class Log
{
    public int Id { get; set; }
    public DateTime Datetime { get; set; }
    public string Action { get; set; }
    public string TableName { get; set; }
    public string Comment { get; set; }
}
