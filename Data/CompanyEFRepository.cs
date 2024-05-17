using Practices.Models;
using Microsoft.EntityFrameworkCore;

namespace Practices.Data
{
    public class CompanyEFRepository : ICompanyRepository
    {
        private readonly PracticesContext _context;

        public CompanyEFRepository(PracticesContext context)
        {
            _context = context;
        }

        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
            SaveChanges();
        }

        public IEnumerable<Company> GetAllCompanies() 
        {
            var companies = _context.Companies;
            return companies;
        }

        public Company GetCompany(int companyId)
        {
            var company = _context.Companies.FirstOrDefault(company => company.Id == companyId);
            return company;
        }

        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteCompany(int companyId) {
            var company = GetCompany(companyId);
            _context.Companies.Remove(company);
            SaveChanges();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
/*
        public void AddBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            SaveChanges();
        }*/

    }   
}