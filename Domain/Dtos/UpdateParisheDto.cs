namespace Domain.Dtos;

public class UpdateParisheDto
{
    public string Id {get; set;}
    public string Name { get; set; }
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Provider { get; set; }
}
