using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces;

public interface IMovieCastsRepository: IRepository<MovieCasts>
{
    List<MovieCasts> GetCastsByMovieId(int movieId);

    List<MovieCasts> GetMoviesByCastId(int castId);
}