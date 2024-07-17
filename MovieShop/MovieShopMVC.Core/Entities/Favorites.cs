using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class Favorites
{
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
}