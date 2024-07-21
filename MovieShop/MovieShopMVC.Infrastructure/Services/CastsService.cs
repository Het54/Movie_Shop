using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Infrastructure.Services;

public class CastsService: ICastsService
{
    private readonly ICastsRepository _castsRepository;

    public CastsService(ICastsRepository castsRepository)
    {
        _castsRepository = castsRepository;
    }

    public List<CastsResponseModel> GetAll()
    {
        var casts = _castsRepository.GetAll();
        var castsResponseModel = new List<CastsResponseModel>();
        foreach (var cast in casts)
        {
            castsResponseModel.Add(new CastsResponseModel()
            {
                Gender = cast.Gender,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            });
        }

        return castsResponseModel;
    }

    public CastsResponseModel GetById(int id)
    {
        var cast = _castsRepository.GetById(id);
        if (cast != null)
        {
            var castResponseModel = new CastsResponseModel()
            {
                Gender = cast.Gender,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            };
            return castResponseModel;
        }

        return null;
    }

    public int Add(CastsRequestModel model)
    {
        var castEntity = new Casts()
        {
            Gender = model.Gender,
            Name = model.Name,
            ProfilePath = model.ProfilePath,
            TmdbUrl = model.TmdbUrl
        };
        return _castsRepository.Insert(castEntity);
    }

    public int DeleteById(int id)
    {
        return _castsRepository.DeleteById(id);
    }

    public int Update(int id, CastsRequestModel model)
    {
        var castEntity = new Casts()
        {
            Id = id,
            Gender = model.Gender,
            Name = model.Name,
            ProfilePath = model.ProfilePath,
            TmdbUrl = model.TmdbUrl
        };
        return _castsRepository.Update(castEntity);
    }
}