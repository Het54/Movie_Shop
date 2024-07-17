using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopMVC.Core.Entities;

public class Reviews
{
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    [Column(TypeName = "datetime2")]
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; }
    [Required]
    public string ReviewText { get; set; }
}