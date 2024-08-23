using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopMVC.main.Models;

public class RegisterViewModel
{
    [Column(TypeName = "datetime2")]
    public DateTime? DateOfBirth { get; set; }
    [MaxLength(256)]
    [Required]
    public string Email { get; set; }
    [MaxLength(128)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(128)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(16)]
    public string? PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
    
}