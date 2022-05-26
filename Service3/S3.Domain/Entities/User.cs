namespace S3.Domain.Entities;

public class User:BaseEntity
{
    public Guid ProductId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}