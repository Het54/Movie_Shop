using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Infrastructure.Services;

namespace MovieShopMVC.main.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _moviesService;

    public MoviesController(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
}