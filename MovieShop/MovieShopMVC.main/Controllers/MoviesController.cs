using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Infrastructure.Services;

namespace MovieShopMVC.main.Controllers;

public class MoviesController : Controller
{
    private readonly MoviesService _service;

    public MoviesController(MoviesService service)
    {
        _service = service;
    }
    // GET
    public IActionResult Index()
    {
        var items = _service.GetAll();
        return View(items);
    }
}