using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class Roles
{
    public int Id { get; set; }
    [MaxLength(20)]
    [Required]
    public string Name { get; set; }
}