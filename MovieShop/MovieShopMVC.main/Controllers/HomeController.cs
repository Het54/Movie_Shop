using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.main.Models;

namespace MovieShopMVC.main.Controllers;

[Authorize(Roles = "User,Admin")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMoviesService _moviesService;
    private readonly IGenresService _genresService;
    private string routeGenre = "";

    public HomeController(ILogger<HomeController> logger, IMoviesService moviesService, IGenresService genresService)
    {
        _logger = logger;
        _moviesService = moviesService;
        _genresService = genresService;
    }
    
    [HttpGet]
    public IActionResult Index(int pageNumber = 1)
    {
        var claimsPrincipal = ExtractClaimsFromToken(Request.Cookies["AuthToken"]);
        var userEmail = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        var userRole = claimsPrincipal.FindFirst("role")?.Value;
        var userName = claimsPrincipal.FindFirst("unique_name")?.Value;
        
        var len = _moviesService.GetAll().Count;
        ViewBag.TotalPages = len / 18;
        ViewBag.items = _moviesService.GetAllMoviesByPages(pageNumber);
        ViewBag.CurrentPage = pageNumber;
        ViewBag.userEmail = userEmail!;
        ViewBag.userRole = userRole!;
        ViewBag.userName = userName!;
        CreateDropDownList();
        
        return View();
    }
    
    [Route("/hello")]
    public IActionResult UpdatedIndex(string selectedGenre, int pageNumber = 1) 
    {
        
        var claimsPrincipal = ExtractClaimsFromToken(Request.Cookies["AuthToken"]);
        var userEmail = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        var userRole = claimsPrincipal.FindFirst("role")?.Value;
        var userName = claimsPrincipal.FindFirst("unique_name")?.Value;
        
        var len = _moviesService.GetMoviesWithGenres(Convert.ToInt32(selectedGenre)).Count;
        ViewBag.TotalPages = len / 18;
        ViewBag.items = _moviesService.GetMoviesWithGenresByPages(Convert.ToInt32(selectedGenre),pageNumber);
        ViewBag.CurrentPage = pageNumber;
        ViewBag.SelectedGenreId = Convert.ToInt32(selectedGenre);
        ViewBag.userEmail = userEmail!;
        ViewBag.userRole = userRole!;
        ViewBag.userName = userName!;
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
        routeGenre = selectedGenre;
    }
    
    [NonAction]
    public ClaimsPrincipal ExtractClaimsFromToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
    
        // Validate if the token is well-formed
        if (!handler.CanReadToken(jwtToken))
        {
            throw new ArgumentException("Invalid JWT token");
        }
    
        var token = handler.ReadJwtToken(jwtToken);
    
        // Create a claims identity
        var claims = token.Claims;
        var identity = new ClaimsIdentity(claims);
    
        // Return the ClaimsPrincipal which can be used for authorization checks
        return new ClaimsPrincipal(identity);
    }
    
}