using Practices.Models;

namespace Practices.Data;

public interface ICompanyRepository
{
    public void AddCompany(Company company);
    public Company GetCompany(int companyId);
    public IEnumerable<Company> GetAllCompanies();
    public void DeleteCompany(int companyId);
    public void UpdateCompany(Company company);
    void SaveChanges();
    /*public void AddBooking(Booking booking);*/
}
