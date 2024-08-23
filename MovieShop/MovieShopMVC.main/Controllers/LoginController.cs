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

        if (token == null)
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