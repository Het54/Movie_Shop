using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class Casts
{
    public int Id { get; set; }
    [Required]
    public string Gender { get; set; }
    [MaxLength(128)]
    [Required]
    public string Name { get; set; }
    [MaxLength(2084)]
    [Required]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
}