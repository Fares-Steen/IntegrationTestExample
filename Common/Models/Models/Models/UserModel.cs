namespace Models.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTime DateAdded { get; set; }

    public DateTime DateUpdated { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}