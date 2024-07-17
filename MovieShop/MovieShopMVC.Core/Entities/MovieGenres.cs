using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class MovieGenres
{
    public int GenreId { get; set; }
    public Genres Genre { get; set; }
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
}