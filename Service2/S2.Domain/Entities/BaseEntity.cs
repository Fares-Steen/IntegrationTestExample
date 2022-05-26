using S2.Domain.Entities.Interfaces;

namespace S2.Domain.Entities;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
}