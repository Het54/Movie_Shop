using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class Genres
{
    public int Id { get; set; }
    [MaxLength(24)]
    [Required(ErrorMessage = "Name of the Genre is required!")]
    public string Name { get; set; }
}