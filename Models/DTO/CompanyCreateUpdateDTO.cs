using System.ComponentModel.DataAnnotations;

namespace Practices.Models;

public class CompanyCreateUpdateDTO
{
    [Required]
    [StringLength(50, ErrorMessage = "El nombre debe tener menos de 50 caracteres")]
    public string? Name { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    public string? Password { get; set; }

    [Required]
    public string? EmployeeCount { get; set; }

    [Required(ErrorMessage = "El valor debe ser 'true' o 'false'")]
    public bool Website { get; set; }  
}