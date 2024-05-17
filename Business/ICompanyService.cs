using Practices.Models;

namespace Practices.Business;

public interface ICompanyService
{
    public Company RegisterCompany(CompanyCreateUpdateDTO companyCreateUpdateDTO);
    public IEnumerable<Company> GetAllCompanies();
    public Company GetCompanyById(int companyId);
    public void UpdateCompany(int companyId, CompanyCreateUpdateDTO companyCreateUpdateDTO);
    public void DeleteCompany(int companyId);
}
