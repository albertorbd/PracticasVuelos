using System.ComponentModel.DataAnnotations;

namespace Practices.Models;
public class Company
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public DateTime FoundationDate { get; set; }

    [Required]
    public string? EmployeeCount { get; set; }

    [Required]
    public bool Website { get; set; }
    
    public List<Booking> Flights { get; set; }

    public Company() {}

    public Company(string name, string password, string employeeCount, bool website) 
    {
        Name = name;
        Password = password;
        FoundationDate = DateTime.Now;
        EmployeeCount = employeeCount;
        Website = website;
        Flights = new List<Booking>();
    }
}
