using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class MovieCasts
{
    public int CastId { get; set; }
    public Casts Cast { get; set; }
    [Required]
    [MaxLength(450)]
    public string Character { get; set; }
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
}