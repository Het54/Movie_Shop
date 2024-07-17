using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.main.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}