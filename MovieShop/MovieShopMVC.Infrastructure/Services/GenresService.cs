using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Infrastructure.Services;

public class GenresService: IGenresService
{
    private readonly IGenresRepository _genresRepository;

    public GenresService(IGenresRepository genresRepository)
    {
        _genresRepository = genresRepository;
    }
    public List<GenresResponseModel> GetAll()
    {
        var genres = _genresRepository.GetAll();
        var genreResponseModel = new List<GenresResponseModel>();
        foreach (var genre in genres)
        {
            genreResponseModel.Add(new GenresResponseModel()
            {
                Id = genre.Id,
                Name = genre.Name
            });
        }

        return genreResponseModel;
    }

    public GenresResponseModel GetById(int id)
    {
        var genre = _genresRepository.GetById(id);
        if (genre != null)
        {
            var genreResponseModel = new GenresResponseModel()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
            return genreResponseModel;
        }

        return null;
    }

    public int Add(GenresRequestModel model)
    {
        var genreEntity = new Genres()
        {
            Name = model.Name
        };
        return _genresRepository.Insert(genreEntity);
    }

    public int DeleteById(int id)
    {
        return _genresRepository.DeleteById(id);
    }

    public int Update(int id, GenresRequestModel model)
    {
        var genreEntity = new Genres()
        {
            Id = id,
            Name = model.Name
        };
        return _genresRepository.Update(genreEntity);
    }
}