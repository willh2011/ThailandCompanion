namespace ThailandCompanion.Api.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}