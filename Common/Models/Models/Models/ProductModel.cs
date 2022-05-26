namespace Models.Models;

public class ProductModel
{
    public Guid Id { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateUpdated { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}