using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Models.RequestModels;

public class PurchasesRequestModel
{
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    [Column(TypeName = "datetime2")]
    [Required]
    public DateTime PurchaseDateTime { get; set; }
    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid PurchaseNumber { get; set; }
    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal TotalPrice { get; set; }
}