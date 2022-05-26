using S1.Domain.Entities;

namespace S1.Domain;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}