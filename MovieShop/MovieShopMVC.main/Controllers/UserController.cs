using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.main.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}