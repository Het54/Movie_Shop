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
    public IActionResult Index(int pageNumber = 1)
    {
        CreateDropDownList();
        var len = _moviesService.GetAll().Count;
        ViewBag.TotalPages = len / 12;
        ViewBag.items = _moviesService.GetMoviesByPages(pageNumber);
        ViewBag.CurrentPage = pageNumber;
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string selectedGenre, int pageNumber = 1) 
    {
        
        if (ModelState.IsValid)
        {
            if (selectedGenre == "Genres")
            {
                ViewBag.items = _moviesService.GetAll();
            }
            else
            {
                var len = _moviesService.GetMoviesWithGenres(Convert.ToInt32(selectedGenre)).Count;
                ViewBag.TotalPages = len / 12;
                ViewBag.items = _moviesService.GetMoviesWithGenresByPages(Convert.ToInt32(selectedGenre), pageNumber);
                ViewBag.CurrentPage = pageNumber;
            }
        }
        CreateDropDownList(selectedGenre);
        return View();
    }
    
    [NonAction]
    private void CreateDropDownList(string selectedGenre = "Genres")
    {
        var genres = _genresService.GetAll().Select(g => new { Key = g.Id, Value = g.Name }).ToList();
        ViewBag.GenreList = new SelectList(genres, "Key", "Value");
        foreach (var genre in genres)
        {
            if (selectedGenre == "Genres")
            {
                break;
            }
            else
            {
                if (genre.Key == Convert.ToInt32(selectedGenre))
                {
                    selectedGenre = genre.Value;
                    break;
                }
            }
        }
        ViewBag.selectedGenre = selectedGenre;
    }
    
}