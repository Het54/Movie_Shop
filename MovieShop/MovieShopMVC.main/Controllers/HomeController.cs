using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.main.Models;

namespace MovieShopMVC.main.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMoviesService _moviesService;
    private readonly IGenresService _genresService;

    public HomeController(ILogger<HomeController> logger, IMoviesService moviesService, IGenresService genresService)
    {
        _logger = logger;
        _moviesService = moviesService;
        _genresService = genresService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        CreateDropDownList();
        ViewBag.items = _moviesService.GetAll();
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string selectedGenre) 
    {
        
        if (ModelState.IsValid)
        {
            Console.WriteLine(selectedGenre);
            ViewBag.items = _moviesService.GetMoviesWithGenres(Convert.ToInt32(selectedGenre));
        }
        ViewBag.SelectedGenre = selectedGenre;
        CreateDropDownList(selectedGenre);
        return View();
    }
    
    [NonAction]
    private void CreateDropDownList(string selectedGenre = "Genres")
    {
        var genres = _genresService.GetAll().Select(g => new { Key = g.Id, Value = g.Name }).ToList();
        ViewBag.GenreList = new SelectList(genres, "Key", "Value");
        ViewBag.selectedGenre = selectedGenre;
    }

    public IActionResult MovieDetails()
    {
        ViewBag.movie = _moviesService.GetById(10);
        return View();
    }
    
}