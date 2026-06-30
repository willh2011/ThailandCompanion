namespace ThailandCompanion.Api.DTOs;

public class DistrictDto
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public int ProvinceId { get; set; }

    public string ProvinceNameEn { get; set; } = string.Empty;

    public string NameEn { get; set; } = string.Empty; 

    public string NameTh { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
}