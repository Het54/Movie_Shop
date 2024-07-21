using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IUsersService
{
    List<UsersResponseModel> GetAll();
    UsersResponseModel GetById(int id);
    int Add(UsersRequestModel model);
    int DeleteById(int id);
    int Update(int id, UsersRequestModel model);
}