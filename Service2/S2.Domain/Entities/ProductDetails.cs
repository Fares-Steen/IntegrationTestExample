namespace S2.Domain.Entities;

public class ProductDetails:BaseEntity
{
    public Guid ProductId { get; set; }
    public int Price { get; set; }
    public int Size { get; set; }
}