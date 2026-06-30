using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Data;
using ThailandCompanion.Api.DTOs;
using ThailandCompanion.Api.Interfaces;

namespace ThailandCompanion.Api.Services;

public class ProvinceService : IProvinceService
{
    private readonly ApplicationDbContext _context;

    public ProvinceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ProvinceDto> GetAll()
    {
        return _context.Provinces
            .OrderBy(p => p.NameEn)
            .Select(p => new ProvinceDto
            {
                Id = p.Id,
                NameEn = p.NameEn,
                NameTh = p.NameTh,
                Slug = p.Slug,
                Code = p.Code
            })
            .ToList();
    }

    public ProvinceDto? GetById(int id)
    {
        return _context.Provinces
            .Where(p => p.Id == id)
            .Select(p => new ProvinceDto
            {
                Id = p.Id,
                NameEn = p.NameEn,
                NameTh = p.NameTh,
                Slug = p.Slug,
                Code = p.Code
            })
            .FirstOrDefault();
    }
}