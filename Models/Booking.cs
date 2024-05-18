using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practices.Models;
public class Booking
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("Company")]
    public int CompanyId { get; set; }

    [Required]
    public string? Origin { get; set; }

    [Required]
    public string? Destination { get; set; }

    [Required]
    public DateTime DepartureDate { get; set; }

    [Required]
    public DateTime ReturnDate { get; set; }

    [Required]
    public double Amount { get; set; }

    public Booking() {}

    public Booking(int userId, int companyId, string origin, string destination, DateTime departureDate, DateTime returnDate, double amount) 
    {
        UserId = userId;
        CompanyId = companyId;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        ReturnDate = returnDate;
        Amount = amount;
    }
}
