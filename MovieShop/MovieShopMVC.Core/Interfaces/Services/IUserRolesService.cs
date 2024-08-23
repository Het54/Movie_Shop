using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IUserRolesService
{
    List<UserRolesResponseModel> GetAll();
}