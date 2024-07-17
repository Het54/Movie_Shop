using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.main.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}