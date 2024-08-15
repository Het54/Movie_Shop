using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IMoviesService
{
    List<MoviesResponseModel> GetAll();

    List<MoviesResponseModel> GetAllMoviesByPages(int pageNumber);
    MoviesResponseModel GetById(int id);
    List<MoviesResponseModel> GetHighestGrossingMovies();
    List<MoviesResponseModel> GetMoviesWithGenresByPages(int id, int pageNumber);
    List<MoviesResponseModel> GetMoviesWithGenres(int id);
    int Add(MoviesRequestModel model);
    int DeleteById(int id);
    int Update(int id, MoviesRequestModel model);
}