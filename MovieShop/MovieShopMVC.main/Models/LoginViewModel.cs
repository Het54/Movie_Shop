using Microsoft.Build.Framework;

namespace MovieShopMVC.main.Models;

public class LoginViewModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
}