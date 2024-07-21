using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IGenresService
{
    List<GenresResponseModel> GetAll();
    GenresResponseModel GetById(int id);
    int Add(GenresRequestModel model);
    int DeleteById(int id);
    int Update(int id, GenresRequestModel model);
}