using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Models.ResponseModels;

public class PurchasesResponseModel
{
    public int MovieId { get; set; }
    public Movies Movie { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseNumber { get; set; }
    public decimal TotalPrice { get; set; }
}