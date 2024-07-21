using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Models.RequestModels;

public class GenresRequestModel
{
    [MaxLength(24)]
    [Required(ErrorMessage = "Name of the Genre is required!")]
    public string Name { get; set; }
}