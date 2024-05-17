using Microsoft.AspNetCore.Mvc;
using Practices.Business;
using Practices.Models;
using Microsoft.AspNetCore.Authorization;

namespace Practices.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ILogger<CompaniesController> _logger;
    private readonly ICompanyService _companyService;

    public CompaniesController(ILogger<CompaniesController> logger, ICompanyService companyService)
    {
        _logger = logger;
        _companyService = companyService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Company>> GetAllCompanies()
    {
        try 
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener todas las compañías. {ex.Message}");
            return BadRequest($"Error al obtener todas las compañías. {ex.Message}");
        }
    }

    [HttpGet("{companyId}")]
    public IActionResult GetCompany(int companyId)
    {
        try
        {
            var company = _companyService.GetCompanyById(companyId);
            return Ok(company);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
           return NotFound($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener la compañía con ID: {companyId}. {ex.Message}");
            return BadRequest($"Error al obtener la compañía con ID: {companyId}. {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyCreateUpdateDTO companyCreateUpdateDTO)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try {
            var company = _companyService.RegisterCompany(companyCreateUpdateDTO);
            return CreatedAtAction(nameof(GetCompany), new { companyId = company.Id }, company);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"Error al registrar la compañía. {ex.Message}");
            return BadRequest($"Error al registrar la compañía. {ex.Message}");
        }
    }

    [HttpPut("{companyId}")]
    public IActionResult UpdateCompany(int companyId, CompanyCreateUpdateDTO companyCreateUpdateDTO)
    {
        try {
            _companyService.UpdateCompany(companyId, companyCreateUpdateDTO);
            return NoContent();
        }     
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
            return NotFound($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar la compañía con ID: {companyId}. {ex.Message}");
            return BadRequest($"Error al actualizar la compañía con ID: {companyId}. {ex.Message}");
        }
    }

    [HttpDelete("{companyId}")]
    public IActionResult DeleteCompany(int companyId)
    {
        try
        {
            _companyService.DeleteCompany(companyId);
            return NoContent();
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
            return NotFound($"No se ha encontrado la compañía con ID: {companyId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar la compañía con ID: {companyId}. {ex.Message}");
            return BadRequest($"Error al eliminar la compañía con ID: {companyId}. {ex.Message}");
        }
    }

}
