using Microsoft.Build.Framework;

namespace MovieShopMVC.main.JWTAuthenticationManager.Models.RequestModel;

public partial class AuthenticationRequestModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string HashedPassword { get; set; }
}