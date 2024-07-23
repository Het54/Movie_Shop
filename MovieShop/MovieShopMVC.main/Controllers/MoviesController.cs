using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Infrastructure.Services;

namespace MovieShopMVC.main.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly ITrailersService _trailersService;
    private readonly IMovieCastsService _movieCastsService;
    public string movieName = "";

    public MoviesController(IMoviesService moviesService, ITrailersService trailersService, IMovieCastsService movieCastsService)
    {
        _moviesService = moviesService;
        _trailersService = trailersService;
        _movieCastsService = movieCastsService;
    }
    
    [HttpGet]
    public IActionResult Index(int id)
    {
        ViewBag.movie = _moviesService.GetById(id);
        ViewBag.tailers = _trailersService.GetByMovieId(id);
        ViewBag.movieCasts = _movieCastsService.GetByMovieId(id);
        return View();
    }

    
}