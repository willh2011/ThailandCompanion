namespace ThailandCompanion.Api.Entities.Common;

public interface IBaseEntity
{
    int Id { get; set; }

    Guid PublicId { get; set; }

    DateTime CreatedAt { get; set; }

    DateTime UpdatedAt { get; set; }
}