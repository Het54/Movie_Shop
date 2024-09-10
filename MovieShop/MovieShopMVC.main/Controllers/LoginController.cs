using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.main.JWTAuthenticationManager;
using MovieShopMVC.main.JWTAuthenticationManager.Models.RequestModel;
using MovieShopMVC.main.Models;

namespace MovieShopMVC.main.Controllers;

public class LoginController : Controller
{
    private readonly IUserRolesService _userRolesService;
    private readonly JWTTokenHandler _jwtTokenHandler;

    public LoginController(IUserRolesService userRolesService, JWTTokenHandler jwtTokenHandler)
    {
        _userRolesService = userRolesService;
        _jwtTokenHandler = jwtTokenHandler;
    }

    public IActionResult Index()
    {
        Response.Cookies.Append("AuthToken", "", new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddDays(-1), // Set expiration to the past
            HttpOnly = true, // Optional: Match attributes of the original cookie
            Secure = true, // Optional: Match attributes of the original cookie
            SameSite = SameSiteMode.Lax // Optional: Match attributes of the original cookie
        });
        
        
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {

        var token = _jwtTokenHandler.GenerateToken(new AuthenticationRequestModel
        {
            Email = model.Email,
            HashedPassword = model.Password
        });

        if (string.IsNullOrEmpty(token.JwtToken))
        {
            return View(model);
        }
        
        Response.Cookies.Append("AuthToken", token.JwtToken, new CookieOptions
        {
            HttpOnly = true, 
            Secure = false, 
            SameSite = SameSiteMode.Strict 
        });
        
        return RedirectToAction("Index","Home");
    }
}