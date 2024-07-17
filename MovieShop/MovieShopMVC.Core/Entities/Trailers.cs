using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class Trailers
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
    [Required]
    [MaxLength(2084)]
    public string Name { get; set; }
    [Required]
    [MaxLength(2084)]
    public string TrailerUrl { get; set; }
}