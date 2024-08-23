using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.main.Models;

namespace MovieShopMVC.main.Controllers;

public class UserController : Controller
{
    private readonly IUsersService _usersService;

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(RegisterViewModel model)
    {
        Console.WriteLine("Inside HTTPPOST Index");
        if (ModelState.IsValid)
        {
            UsersRequestModel usersRequestModel = new UsersRequestModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HashedPassword = model.Password,
                Salt = "E9v4X3Y7t1Q9m2R5",
                IsLocked = false
            };

            _usersService.Add(usersRequestModel);

            return RedirectToAction("Index", "Home");
        }

        return View(model);

    }
}