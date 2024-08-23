namespace MovieShopMVC.main.JWTAuthenticationManager.Models.RequestModel;

public class AuthenticationResponseModel
{
    public string Email { get; set; }
    public string JwtToken { get; set; }
    public int ExpireIn { get; set; }
}