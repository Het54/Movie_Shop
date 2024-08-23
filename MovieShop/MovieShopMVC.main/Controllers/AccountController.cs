using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.main.Models;

namespace MovieShopMVC.main.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}