namespace Domain.Entities;

public class Expense
{
    public string Id {get; set;}
    public string Name { get; set; }
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double TotalAmount { get; set; }
    public string Provider { get; set; }
}
