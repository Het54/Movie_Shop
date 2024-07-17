using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopMVC.Core.Entities;

public class Users
{
    public int Id { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime? DateOfBirth { get; set; }
    [MaxLength(256)]
    [Required]
    public string Email { get; set; }
    [MaxLength(128)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(1024)]
    [Required]
    public string HashedPassword { get; set; }
    public bool? IsLocked { get; set; }
    [MaxLength(128)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(16)]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [MaxLength(1024)]
    [Required]
    public string Salt { get; set; }
}