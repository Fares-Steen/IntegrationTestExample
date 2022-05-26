namespace S1.Domain.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
}