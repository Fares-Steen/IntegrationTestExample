namespace Models.Models;

public class ProductDetailsModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    
    public DateTime DateAdded { get; set; }

    public DateTime DateUpdated { get; set; }
    public int Size { get; set; }
    public int Price { get; set; }
}