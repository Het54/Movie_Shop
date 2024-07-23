using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface IMovieCastsService
{
    List<MovieCasts> GetByMovieId(int movieid);

    List<MovieCasts> GetMoviesByCastId(int castId);
}