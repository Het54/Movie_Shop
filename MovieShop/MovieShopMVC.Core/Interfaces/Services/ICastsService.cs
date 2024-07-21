using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface ICastsService
{
    List<CastsResponseModel> GetAll();
    CastsResponseModel GetById(int id);
    int Add(CastsRequestModel model);
    int DeleteById(int id);
    int Update(int id, CastsRequestModel model);
}