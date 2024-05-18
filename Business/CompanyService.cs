using Practices.Data;
using Practices.Models;

namespace Practices.Business;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public Company RegisterCompany(CompanyCreateUpdateDTO companyCreateUpdateDTO)
    {
        Company company = new(companyCreateUpdateDTO.Name, companyCreateUpdateDTO.Password, companyCreateUpdateDTO.EmployeeCount, companyCreateUpdateDTO.Website);
        _companyRepository.AddCompany(company);
        return company;
    }

    public IEnumerable<Company> GetAllCompanies()
    {
        return _companyRepository.GetAllCompanies();
    }

    public Company GetCompanyById(int companyId)
    {
        var company = _companyRepository.GetCompany(companyId);
        if (company == null)
        {
            throw new KeyNotFoundException($"Compañía con ID {companyId} no encontrada");
        }
        return company;
    }
    
    public void UpdateCompany(int companyId, CompanyCreateUpdateDTO companyCreateUpdateDTO)
    {
        var company = _companyRepository.GetCompany(companyId);
        if (company == null)
        {
            throw new KeyNotFoundException($"Compañía con ID {companyId} no encontrada");
        }
        company.Name = companyCreateUpdateDTO.Name;
        company.Password = companyCreateUpdateDTO.Password;
        company.EmployeeCount = companyCreateUpdateDTO.EmployeeCount;
        company.Website = companyCreateUpdateDTO.Website;
        _companyRepository.UpdateCompany(company);
    }

    public void DeleteCompany(int companyId)
    {
        var company = _companyRepository.GetCompany(companyId);
        if (company == null)
        {
            throw new KeyNotFoundException($"Compañía con ID {companyId} no encontrada");
        }
        _companyRepository.DeleteCompany(companyId);
    }
    
}