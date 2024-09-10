using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IUserRolesService
{
    List<UserRolesResponseModel> GetAll();
    
    int Add(UserRolesRequestModel model);
}