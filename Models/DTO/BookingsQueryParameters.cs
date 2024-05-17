using System.ComponentModel.DataAnnotations;

namespace Practices.Models;

public class BookingsQueryParameters
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario no es válido")]
    public int UserId { get; set; }
    
    public DateTime? DepartureDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}