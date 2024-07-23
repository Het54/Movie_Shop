using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;

namespace MovieShopMVC.main.Controllers;

public class CastController : Controller
{
    private readonly ICastsService _castsService;
    private readonly IMoviesService _moviesService;
    private readonly IMovieCastsService _movieCastsService;

    public CastController(ICastsService castsService, IMoviesService moviesService, IMovieCastsService movieCastsService)
    {
        _castsService = castsService;
        _moviesService = moviesService;
        _movieCastsService = movieCastsService;
    }
    
    [HttpGet]
    public IActionResult Index(int castid, int movieid)
    {
        ViewBag.castDetails = _castsService.GetById(castid);
        ViewBag.moviePosterUrl = _moviesService.GetById(movieid).PosterUrl;
        ViewBag.moviesByCast = _movieCastsService.GetMoviesByCastId(castid);
        return View();
    }
}