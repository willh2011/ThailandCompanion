using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Data;
using ThailandCompanion.Api.DTOs;
using ThailandCompanion.Api.Interfaces;

namespace ThailandCompanion.Api.Services;

public class DistrictService : IDistrictService
{
    private readonly ApplicationDbContext _context;

    public DistrictService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<DistrictDto> GetAll()
    {
        return _context.Districts
            .Include(d => d.Province)
            .OrderBy(d => d.NameEn)
            .Select(d => new DistrictDto
            {
                Id = d.Id,
                PublicId = d.PublicId,
                ProvinceId = d.ProvinceId,
                ProvinceNameEn = d.Province.NameEn,
                NameEn = d.NameEn,
                NameTh = d.NameTh,
                Slug = d.Slug
            })
            .ToList();
    }

    public List<DistrictDto> GetByProvinceId(int provinceId)
    {
        return _context.Districts
            .Include(d => d.Province)
            .Where(d => d.ProvinceId == provinceId)
            .OrderBy(d => d.NameEn)
            .Select(d => new DistrictDto
            {
                Id = d.Id,
                PublicId = d.PublicId,
                ProvinceId = d.ProvinceId,
                ProvinceNameEn = d.Province.NameEn,
                NameEn = d.NameEn,
                NameTh = d.NameTh,
                Slug = d.Slug
            })
            .ToList();
    }

    public DistrictDto? GetById(int id)
    {
        return _context.Districts
            .Include(d => d.Province)
            .Where(d => d.Id == id)
            .Select(d => new DistrictDto
            {
                Id = d.Id,
                PublicId = d.PublicId,
                ProvinceId = d.ProvinceId,
                ProvinceNameEn = d.Province.NameEn,
                NameEn = d.NameEn,
                NameTh = d.NameTh,
                Slug = d.Slug
            })
            .FirstOrDefault();
    }
}