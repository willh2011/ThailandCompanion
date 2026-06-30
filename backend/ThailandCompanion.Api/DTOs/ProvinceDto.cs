namespace ThailandCompanion.Api.DTOs;

public class ProvinceDto
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public string NameEn { get; set; } = string.Empty;

    public string NameTh { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}