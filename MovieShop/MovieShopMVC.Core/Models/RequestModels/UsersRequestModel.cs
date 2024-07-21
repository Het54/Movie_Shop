using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopMVC.Core.Models.RequestModels;

public class UsersRequestModel
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
    public string? ProfilePictureUrl { get; set; }
}