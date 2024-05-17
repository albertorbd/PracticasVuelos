using System.ComponentModel.DataAnnotations;

namespace Practices.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? Phone { get; set; }
    
    [Required]
    public string? DNI { get; set; }

    [Required]
    public List<Booking> MyBookings { get; set; }

    public User() {}

    public User(string name, string email, string password, string phone, string dni) 
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        DNI = dni;
        MyBookings = new List<Booking>();
    }
}
