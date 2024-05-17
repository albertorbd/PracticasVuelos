using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practices.Models;
public class Booking
{
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Company")]
    public int CompanyId { get; set; }

    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double Amount { get; set; }

    public static int BookingIdSeed { get; set; }

    public Booking() {}

    public Booking(string origin, string destination, DateTime departureDate, DateTime returnDate, double amount) 
    {
        Id = BookingIdSeed++;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        ReturnDate = returnDate;
        Amount = amount;
    }
}
