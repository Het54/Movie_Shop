using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IMoviesService
{
    List<MoviesResponseModel> GetAll();
    MoviesResponseModel GetById(int id);
    int Add(MoviesRequestModel model);
    int DeleteById(int id);
    int Update(int id, MoviesRequestModel model);
}