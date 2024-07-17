using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.main.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}