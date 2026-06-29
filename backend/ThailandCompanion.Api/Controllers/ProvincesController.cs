using Microsoft.AspNetCore.Mvc;
using ThailandCompanion.Api.Services;

namespace ThailandCompanion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly ProvinceService _provinceService;

    public ProvincesController(ProvinceService provinceService)
    {
        _provinceService = provinceService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_provinceService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var province = _provinceService.GetByID(id);

        if (province is null)
        {
            return NotFound();
        }

        return Ok(province);
    }

}



